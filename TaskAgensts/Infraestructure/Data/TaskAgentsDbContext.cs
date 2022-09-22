namespace TaskAgents.Infraestructure.Data;

public class TaskAgentsDbContext : DbContext
{

    /// <summary>
    /// IdentityTask DbContext 
    /// </summary>
    /// <param name="options">Options constructor database</param>
    public TaskAgentsDbContext(DbContextOptions<TaskAgentsDbContext> options) : base(options) { }

    public DbSet<TaskApplication> Tasks { get; set; }
    public DbSet<TypeTask> TypeTasks { get; set; }
    public DbSet<ActivityTask> Activities { get; set; }

    /// <summary>
    /// OnModelCreating builder constructor
    /// </summary>
    /// <param name="builder">model builder</param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
