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
        /*
        Authenticate: To authenticate basically means to use the given information and attempt to authenticate the user with that information. So this will attempt to create a user identity and make it available for the framework.

        For example, the cookie authentication scheme uses cookie data to restore the user identity. Or the JWT Bearer authentication scheme will use the token that is provided as part of the Authorization header in the request to create the user identity.

        Challenge: When an authentication scheme is challenged, the scheme should prompt the user to authenticate themselves. This could for example mean that the user gets redirected to a login form, or that there will be a redirect to an external authentication provider.

        Read this: https://www.mmbyte.com/article/29683.html
        */
        public static IServiceCollection AddJWTAuthentication(this IServiceCollection services)  
        {              
            var key = Encoding.ASCII.GetBytes(AuthSettings.Secret);  
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(x =>  
            {  
                x.TokenValidationParameters = new TokenValidationParameters  
                {  
                    IssuerSigningKey = new SymmetricSecurityKey(key),  //Chave para validar a assinatura do token
                    ValidateIssuer = false,  
                    ValidateAudience = false,                      
                };  
            });  
  
            return services;  
        }  
    }  
}