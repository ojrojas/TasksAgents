namespace TaskAgents.Infraestructure.Data;
public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, IAggregateRoot
{
    private readonly TaskAgentsDbContext _context;
    private readonly ISpecificationEvaluator _specificationEvalutator;
    private readonly ILogger<GenericRepository<T>> _logger;

    public GenericRepository(TaskAgentsDbContext context, ILogger<GenericRepository<T>> logger) : this(context, SpecificationEvaluator.Default, logger) { }

    public GenericRepository(TaskAgentsDbContext context, ISpecificationEvaluator specificationEvalutator, ILogger<GenericRepository<T>> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _specificationEvalutator = specificationEvalutator ?? throw new ArgumentNullException(nameof(specificationEvalutator));
    }

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Add async entity {JsonSerializer.Serialize(entity)}");
        await _context.Set<T>().AddAsync(entity, cancellationToken);
        await SaveAsync(cancellationToken);
        return entity;
    }

    public async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Update async entity {JsonSerializer.Serialize(entity)}");
        _context.Entry(entity).State = EntityState.Modified;
        await SaveAsync(cancellationToken);
        return entity;
    }

    public async Task<T> DeleteAsync(T entity, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Delete async entity {JsonSerializer.Serialize(entity)}");
        _context.Set<T>().Remove(entity);
        await SaveAsync(cancellationToken);
        return entity;
    }

    public async Task<IEnumerable<T>> DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Delete async entities {JsonSerializer.Serialize(entities)}");
        _context.Set<T>().RemoveRange(entities);
        await SaveAsync(cancellationToken);
        return entities;
    }

    public async Task<T> FirstAsync(ISpecification<T> specification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Use specification model {typeof(T)}");
        var spec = ApplySpecification(specification);
        return await spec.FirstAsync(cancellationToken);
    }

    public async Task<T> GetByIdAsync(Guid Id, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Get by id async parameter: {Id}");
        return await _context.Set<T>().FindAsync(new object[] { Id }, cancellationToken);
    }

    public async Task<T> FirstOrDefaultAsync(ISpecification<T> specification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"specification model {typeof(T)}");
        var spec = ApplySpecification(specification);
        return await spec.FirstOrDefaultAsync(cancellationToken);
    }

    protected virtual IQueryable<T> ApplySpecification(ISpecification<T> specification, bool evaluateCriteriaOnly = default)
    {
        _logger.LogInformation($"specification model {typeof(T)}");
        if (specification is null) throw new ArgumentNullException(nameof(specification));
        return _specificationEvalutator.GetQuery(_context.Set<T>().AsQueryable<T>(), specification, evaluateCriteriaOnly);
    }

    protected virtual IQueryable<TResult> ApplySpecification<TResult>(ISpecification<T, TResult> specification)
    {
        _logger.LogInformation($"specification model {typeof(T)}");
        if (specification is null) throw new ArgumentNullException(nameof(specification));
        if (specification.Selector is null) throw new SelectorNotFoundException();

        return _specificationEvalutator.GetQuery(_context.Set<T>().AsQueryable(), specification);
    }

    public async Task<IReadOnlyList<T>> ListAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Get list async type model {typeof(T)}");
        return await _context.Set<T>().ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"specification model {typeof(T)}");
        var spec = ApplySpecification(specification);
        return await spec.ToListAsync(cancellationToken);
    }

    public async Task<int> CountAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Count entities async");
        return await _context.Set<T>().CountAsync(cancellationToken);
    }

    public async Task<int> CountAsync(ISpecification<T> specification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Count entities async typeof {typeof(T)}");
        var spec = ApplySpecification(specification);
        return await spec.CountAsync(cancellationToken);
    }

    private async Task SaveAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
        _logger.LogInformation("Save async service");
    }
}
