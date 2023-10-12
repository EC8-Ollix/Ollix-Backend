namespace Ollix.API.Endpoints.Users.Shared
{
    public record UpsertUserRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserPassword { get; set; }
    }
}
