var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);
    var configuration = builder.Configuration;

    builder.Services.AddDbContext<TaskAgentsDbContext>(options =>
    {
        options.UseSqlite(configuration.GetConnectionString("ConnectionSqliteTaskAgents"));
    });

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGenDocumention();
    builder.Services.AddServicesDIApp();

    builder.Services.AddDIOptionsConfiguration(configuration);
    builder.Services.AddJwtExtension(configuration);
    builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: "TaskAgensts",
        builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
    });


    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseCors("TaskAgensts");
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}
