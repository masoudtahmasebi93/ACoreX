using ACoreX.Authentication.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;
using ACoreX.Authentication.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace ACoreX.Authentication.JWT
{

    public class JWTAuthService : IAuthService
    {

        public JWTAuthService(IServiceCollection service, string stringKey)
        {
            byte[] key = Encoding.ASCII.GetBytes(stringKey);
            service.AddSingleton<IToken, JWTToken>();
            

            service.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }


    }
}

