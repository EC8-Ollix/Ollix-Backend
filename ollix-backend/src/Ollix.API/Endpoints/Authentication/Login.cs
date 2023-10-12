using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Ollix.API.Shared;
using Ollix.Domain.Aggregates.UserAppAggregate.Models;
using Ollix.Infrastructure.IoC.Configs.Options;
using Ollix.Infrastructure.IoC.Extensions;
using Ollix.SharedKernel.Extensions;
using Swashbuckle.AspNetCore.Annotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ollix.API.Endpoints.Authentication
{
    [AllowAnonymous]
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
          OperationId = "authentication.login",
          Tags = new[] { "Authentication" }
        )]
        public override async Task<ActionResult<LoginResponse>> HandleAsync([FromBody] LoginRequest request,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(request.ToCommand(), cancellationToken);

            string token = string.Empty;
            if (result.IsSuccess)
                token = GenerateToken(result.Value);

            return result.Handle()
                        .OnSuccess(resultValue => Ok(new LoginResponse(token, resultValue)))
                        .OnError(errors => BadRequest(result.ToErrorModel()))
                        .OnInvalid(errors => BadRequest(result.ToErrorModel()))
                        .Return();
        }

        private string GenerateToken(UserInfo user)
        {
            List<Claim> claims = new()
            {
                new Claim(ApplicationClaims.UserId, user.Id.ToString()),
                new Claim(ApplicationClaims.FirstName, user.FirstName!),
                new Claim(ApplicationClaims.LastName, user.LastName!),
                new Claim(ApplicationClaims.Email, user.UserEmail!),
                new Claim(ApplicationClaims.ClientId, user.ClientApp!.Id.ToString()),
                new Claim(ApplicationClaims.UserType, user.UserType.GetDescription()),

                new Claim(ClaimTypes.Role, user.UserType.GetDescription())
            };

            var jwtSettings = _configuration.GetJwtSettings() ?? new JwtSettings();

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(jwtSettings.Key!));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(TimeSpan.FromHours(8)),
                Issuer = jwtSettings.Issuer,
                Audience = jwtSettings.Audience,
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
