using System;
using System.Text;
using System.Threading.Tasks;
using FaceImage.Api.Models.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace FaceImage.Api
{
    public static class StartupExtensions
    {
        public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            //TODO - move this somewhere secure, KEY VAULT?
            //TODO
            var SecretKey = "iNivDmHLpUA223sqsfhqGbMRdRj1PVkH"; // todo: get this from somewhere secure
            var _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));

        // Get options from app settings
        var jwtAppSettingOptions = configuration.GetSection(nameof(JwtIssuerOptions));

            // Configure JwtIssuerOptions
            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                   .AddJwtBearer(configureOptions =>
                    {
                        configureOptions.ClaimsIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                        configureOptions.TokenValidationParameters = tokenValidationParameters;
                        configureOptions.SaveToken = true;
                        configureOptions.Events = new JwtBearerEvents();
                        
                        //add in bearer events
                        configureOptions.Events.OnMessageReceived += OnMessageReceived;
                        configureOptions.Events.OnAuthenticationFailed += OnAuthenticationFailed;
                        configureOptions.Events.OnTokenValidated += OnTokenValidated;
                    });


            // api user claim policy
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiUser", policy => policy.RequireClaim(Constants.Strings.JwtClaimIdentifiers.Rol, Constants.Strings.JwtClaims.ApiAccess));
            });
        }

        private static Task OnTokenValidated(TokenValidatedContext arg)
        {
            var s = "string";

            return Task.CompletedTask;
        }

        private static Task OnAuthenticationFailed(AuthenticationFailedContext arg)
        {
            var s = "string";

            return Task.CompletedTask;
        }

        private static Task OnMessageReceived(MessageReceivedContext arg)
        {
            var str = "test";

            return Task.CompletedTask;
        }
    }
}
