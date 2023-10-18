using Ollix.Domain.Abstractions;
using Ollix.Domain.Aggregates.ClientAppAggregate;
using Ollix.SharedKernel;

namespace Ollix.Domain.Aggregates.UserAppAggregate
{
    public class UserApp : EntityBase, IClientAppEntity
    {
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public UserType UserType { get; private set; }
        public string? UserEmail { get; private set; }
        public string? UserPassword { get; private set; }
        public Guid ClientId { get; private set; }
        public ClientApp? ClientApp { get; set; }

        public UserApp() { }

        public UserApp(string firstName, string lastName, UserType userType, string userEmail, string userPassword, Guid clientId)
        {
            FirstName = firstName;
            LastName = lastName;
            UserType = userType;
            UserEmail = userEmail;
            UserPassword = userPassword;
            ClientId = clientId;
        }

        public void SetFirstName(string firstName)
        {
            if (string.IsNullOrEmpty(firstName)) return;

            this.FirstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            if (string.IsNullOrEmpty(lastName)) return;

            this.LastName = lastName;
        }

        public void SetUserPassword(string userPassword)
        {
            if (string.IsNullOrEmpty(userPassword)) return;

            this.UserPassword = userPassword;
        }
    }
}
