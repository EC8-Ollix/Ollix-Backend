namespace Ollix.API.Shared
{
    public static class Routes
    {
        private const string BaseUri = "api";

        public const string LoginUri = $"{BaseUri}/auth/login";
        public const string RegisterUri = $"{BaseUri}/auth/register";

        public const string HelicesUri = $"{BaseUri}/helices";
        public const string UsersUri = $"{BaseUri}/users";
    }
}
