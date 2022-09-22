namespace IdentityTask.Infraestructure.Data
{
    public class IdentityTaskDbContext : DbContext
    {
        /// <summary>
        /// IdentityTask DbContext 
        /// </summary>
        /// <param name="options">Options constructor database</param>
        public IdentityTaskDbContext(DbContextOptions<IdentityTaskDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<TypeUser> TypeUsers { get; set; }
        public DbSet<UserApplication> UserApplications { get; set; }

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
}