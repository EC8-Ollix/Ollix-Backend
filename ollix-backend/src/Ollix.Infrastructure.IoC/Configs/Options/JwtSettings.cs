﻿namespace Ollix.Infrastructure.IoC.Configs.Options
{
    public class JwtSettings
    {
        public string? Key { get; set; }
        public string? Audience { get; set; }
        public string? Issuer { get; set; }
    }
}
