namespace TaskAgents.Core.Services
{
    public class TaskApplicationService : ITaskApplicationService
    {
        private readonly IGenericRepository<TaskApplication> _repository;
        private readonly ILogger<TaskApplicationService> _logger;

        public TaskApplicationService(IGenericRepository<TaskApplication> repository, ILogger<TaskApplicationService> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<CreateTaskApplicationResponse> CreateTaskApplicationAsync(CreateTaskApplicationRequest request, CancellationToken cancellationToken)
        {
            CreateTaskApplicationResponse response = new(request.CorrelationId());
            _logger.LogInformation($"Create TaskApplication request correlation: {response.CorrelationId}");
            response.TaskApplicationCreated = await _repository.AddAsync(request.TaskApplication, cancellationToken);
            response.Message = "TaskApplication created success";
            _logger.LogInformation("Create successfull");
            return response;
        }

        public async Task<DeleteTaskApplicationResponse> DeleteTaskApplicationAsync(DeleteTaskApplicationRequest request, CancellationToken cancellationToken)
        {
            DeleteTaskApplicationResponse response = new(request.CorrelationId());
            _logger.LogInformation($"delete TaskApplication by id : {request.Id},  request correlation: {response.CorrelationId}");
            var TaskApplicationFound = await _repository.GetByIdAsync(request.Id, cancellationToken);
            response.TaskApplicationDeleted = await _repository.DeleteAsync(TaskApplicationFound, cancellationToken);
            response.Message = "Delete TaskApplication success";
            _logger.LogInformation("Delete request successfull");
            return response;
        }

        public async Task<GetAllTaskApplicationResponse> GetAllTaskApplicationAsync(GetAllTaskApplicationRequest request, CancellationToken cancellationToken)
        {
            GetAllTaskApplicationResponse response = new(request.CorrelationId());
            _logger.LogInformation($"Get all TaskApplication request correlation: {response.CorrelationId}");
            response.TaskApplications = await _repository.ListAsync(cancellationToken);
            response.Message = "Get all TaskApplications success";
            _logger.LogInformation("Get successfull");
            return response;
        }

        public async Task<GetTaskApplicationByIdResponse> GetTaskApplicationByIdAsync(GetTaskApplicationByIdRequest request, CancellationToken cancellationToken)
        {
            GetTaskApplicationByIdResponse response = new(request.CorrelationId());
            _logger.LogInformation($"Get TaskApplication by id request correlation: {response.CorrelationId}");
            response.TaskApplication = await _repository.GetByIdAsync(request.Id, cancellationToken);
            response.Message = "Get TaskApplication by id success";
            _logger.LogInformation("Get successfull");
            return response;
        }

        public async Task<UpdateTaskApplicationResponse> UpdateTaskApplicationAsync(UpdateTaskApplicationRequest request, CancellationToken cancellationToken)
        {
            UpdateTaskApplicationResponse response = new(request.CorrelationId());
            _logger.LogInformation($"Update TaskApplication request correlation: {response.CorrelationId}");
            response.TaskApplicationUpdated = await _repository.UpdateAsync(request.TaskApplication, cancellationToken);
            response.Message = "Update TaskApplication success";
            _logger.LogInformation("Updated successfull");
            return response;
        }
    }
}
