using System.Text;  
using Microsoft.IdentityModel.Tokens;  
using Microsoft.Extensions.Configuration;  
using Microsoft.Extensions.DependencyInjection;  
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ApiAuth;

namespace AuthTest.API.Middleware  
{  
    public static class AuthenticationExtension  
    {  
        public static IServiceCollection AddJWTAuthentication(this IServiceCollection services)  
        {              
            var key = Encoding.ASCII.GetBytes(AuthSettings.Secret);  
            
            services.AddAuthentication(x =>  
            {  
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;  
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;  
            })  
            .AddJwtBearer(x =>  
            {  
                x.TokenValidationParameters = new TokenValidationParameters  
                {  
                    IssuerSigningKey = new SymmetricSecurityKey(key),  
                    ValidateIssuer = false,  
                    ValidateAudience = false,                      
                };  
            });  
  
            return services;  
        }  
    }  
}