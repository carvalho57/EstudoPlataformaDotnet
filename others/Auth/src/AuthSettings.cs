using Microsoft.Extensions.Configuration;

namespace ApiAuth
{
    public class AuthSettings
    {
        public static string Secret;
        public static string ExpireDate;

        public AuthSettings(IConfiguration configuration)
        {
            Secret = configuration.GetSection("JWT")
                                   .GetSection("Secret").Value;
            Secret = configuration.GetSection("JWT")
                        .GetSection("Secret").Value;
        }
    }
}