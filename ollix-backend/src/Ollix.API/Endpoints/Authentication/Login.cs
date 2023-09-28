﻿using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using Ollix.API.Shared;
using Ollix.API.Shared.Request;
using Ollix.Application.UseCases.Authentication.Shared;
using Ollix.Domain.UserAggregate;
using Ollix.SharedKernel.Extensions;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ollix.API.Endpoints.Authentication
{
    public class Login : EndpointBaseAsync
            .WithRequest<LoginRequest>
            .WithActionResult<LoginResponse>
    {
        protected readonly IMediator _mediator;
        protected readonly IConfiguration _configuration;
        public Login(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        [HttpPost(Routes.LoginUri)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResponse))]
        [SwaggerOperation(
          Summary = "Autenticar na plataforma",
          Description = "Realiza Login na plataforma",
          OperationId = "authentication.login"
        )]
        public override async Task<ActionResult<LoginResponse>> HandleAsync([FromBody] LoginRequest request,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(request.ToCommand(), cancellationToken);

            string token = string.Empty;
            if (result.IsSuccess)
                token = GenerateToken(result.Value);

            return result.Handle()
                        .OnSuccess(r => Ok(new LoginResponse(token, r)))
                        .OnError(errors => BadRequest(result.Errors))
                        .OnInvalid(errors => BadRequest(result.ValidationErrors))
                        .Return();
        }

        private string GenerateToken(UserInfo user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.FirstName!),
                new Claim(ClaimTypes.Email, user.UserEmail!),
                new Claim(ClaimTypes.Role, user.UserType.GetDescription())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims, 
                expires: DateTime.Now.AddDays(1), 
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
