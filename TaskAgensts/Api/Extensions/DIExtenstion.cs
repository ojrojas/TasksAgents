namespace TaskAgents.Api.Extensions;

internal static class AddExtensionInjectDependencies
{
    public static IServiceCollection AddServicesDIApp(this IServiceCollection services)
    {
        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddTransient<ITypeTaskService, TypeTaskService>();
        services.AddTransient<IActivityTaskService, ActivityTaskService>();
        services.AddTransient<ITaskApplicationService, TaskApplicationService>();


        return services;
    }

}