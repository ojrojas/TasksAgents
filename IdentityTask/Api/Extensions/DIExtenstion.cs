namespace IdentityTask.Api.Extensions;
internal static class AddExtensionInjectDependencies
{
    public static IServiceCollection AddServicesDIApp(this IServiceCollection services)
    {
        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddTransient<IEncryptService, EncryptService>();
        services.AddTransient<ITokenClaimService, TokenClaimService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<ITypeUserService, TypeUserService>();
        services.AddTransient<IUserApplicationService, UserApplicationService>();

        return services;
    }
    
}