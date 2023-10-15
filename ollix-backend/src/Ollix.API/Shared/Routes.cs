namespace Ollix.API.Shared
{
    public static class Routes
    {
        private const string BaseUri = "api";

        public const string LoginUri = $"{BaseUri}/auth/login";
        public const string RegisterUri = $"{BaseUri}/auth/register";


        public const string ClientsUri = $"{BaseUri}/clients";
        public const string UsersUri = $"{BaseUri}/users";
        public const string LogsUri = $"{BaseUri}/logs";
        public const string AdressesUri = $"{BaseUri}/adresses";
        public const string OrdersUri = $"{BaseUri}/orders";
        public const string PropellersUri = $"{BaseUri}/propellers";
    }
}
