namespace TaskAgents.Core.Services
{
    public class TypeTaskService : ITypeTaskService
    {
        private readonly IGenericRepository<TypeTask> _repository;
        private readonly ILogger<TypeTaskService> _logger;

        public TypeTaskService(IGenericRepository<TypeTask> repository, ILogger<TypeTaskService> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<CreateTypeTaskResponse> CreateTypeTaskAsync(CreateTypeTaskRequest request, CancellationToken cancellationToken)
        {
            CreateTypeTaskResponse response = new(request.CorrelationId());
            _logger.LogInformation($"Create type task request correlation: {response.CorrelationId}");
            response.TypeTaskCreated = await _repository.AddAsync(request.TypeTask, cancellationToken);
            response.Message = "Type task created success";
            _logger.LogInformation("Create successfull");
            return response;
        }

        public async Task<DeleteTypeTaskResponse> DeleteTypeTaskAsync(DeleteTypeTaskRequest request, CancellationToken cancellationToken)
        {
            DeleteTypeTaskResponse response = new(request.CorrelationId());
            _logger.LogInformation($"delete Type task by id : {request.Id},  request correlation: {response.CorrelationId}");
            var TypeUserFound = await _repository.GetByIdAsync(request.Id, cancellationToken);
            response.TypeTaskDeleted = await _repository.DeleteAsync(TypeUserFound, cancellationToken);
            response.Message = "Delete type task success";
            _logger.LogInformation("Delete request successfull");
            return response;
        }

        public async Task<GetAllTypeTaskResponse> GetAllTypeTaskAsync(GetAllTypeTaskRequest request, CancellationToken cancellationToken)
        {
            GetAllTypeTaskResponse response = new(request.CorrelationId());
            _logger.LogInformation($"Get all type task request correlation: {response.CorrelationId}");
            response.TypeTasks = await _repository.ListAsync(cancellationToken);
            response.Message = "Get all type task success";
            _logger.LogInformation("Get all successfull");
            return response;
        }

        public async Task<UpdateTypeTaskResponse> UpdateTypeTaskAsync(UpdateTypeTaskRequest request, CancellationToken cancellationToken)
        {
            UpdateTypeTaskResponse response = new(request.CorrelationId());
            _logger.LogInformation($"Update type task request correlation: {response.CorrelationId}");
            response.TypeTaskUpdated = await _repository.UpdateAsync(request.TypeTask, cancellationToken);
            response.Message = "Update type task success";
            _logger.LogInformation("Updated successfull");
            return response;
        }
    }
}
