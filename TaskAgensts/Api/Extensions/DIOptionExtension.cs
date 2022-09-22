namespace IdentityTask.Api.Extensions;

internal static class DIOptionExtension {
    public static IServiceCollection AddDIOptionsConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<OptionToken>(configuration.GetSection("Jwt"));
        return services;
    }
}