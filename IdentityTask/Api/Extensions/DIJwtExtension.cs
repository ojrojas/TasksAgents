namespace IdentityTask.Api.Extensions;

/// <summary>
/// Dependency Injection Jwt
/// </summary>
public static class DIJwtExtension
{
    /// <summary>
    /// Extension Jwt configuration
    /// </summary>
    /// <param name="services">Services application</param>
    /// <param name="configuration">configuration environments</param>
    /// <returns>Service configuration</returns>
    internal static IServiceCollection AddJwtExtension(this IServiceCollection services, IConfiguration configuration)
    {
       var key = Encoding.ASCII.GetBytes(configuration["Jwt:SecretPhrase"]);
            services.AddAuthentication(config =>
            {
                config.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(config =>
            {
                config.RequireHttpsMetadata = false;
                config.SaveToken = true;
                config.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return services;
    }
}