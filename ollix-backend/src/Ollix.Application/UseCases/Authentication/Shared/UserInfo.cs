using Ollix.Domain.ClientAppAggregate;
using Ollix.Domain.UserAggregate;

namespace Ollix.Application.UseCases.Authentication.Shared
{
    public record UserInfo
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserEmail { get; set; }
        public UserType UserType { get; set; }
        public ClientApp? ClientApp { get; set; }

        public UserInfo(UserApp user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            UserEmail = user.UserEmail;
            UserType = user.UserType;
            ClientApp = new ClientApp()
            {
                Id = user.Id
            };
        }

        public UserInfo(UserApp user, ClientApp clientApp)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            UserEmail = user.UserEmail;
            UserType = user.UserType;
            ClientApp = clientApp;
        }
    }
}
