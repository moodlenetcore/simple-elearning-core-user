using Microsoft.IdentityModel.Tokens;
using System;

namespace MoodleNetCore.User.Api.Helpers
{
    public static class TokenAuthOption
    {
        public static string Audience = "ExampleAudience";
        public static string Issuer = "ExampleIssuer";
        public static RsaSecurityKey Key = new RsaSecurityKey(RSAKeyHelper.GenerateKey());
        public static SigningCredentials SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);

        public static TimeSpan ExpiresSpan = TimeSpan.FromMinutes(40);
        public static string TokenType = "Bearer";
    }
}
