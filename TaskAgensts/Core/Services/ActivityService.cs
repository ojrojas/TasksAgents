namespace TaskAgents.Core.Services
{
    public class ActivityTaskService : IActivityTaskService
    {
        private readonly IGenericRepository<ActivityTask> _repository;
        private readonly ILogger<ActivityTaskService> _logger;

        public ActivityTaskService(IGenericRepository<ActivityTask> repository, ILogger<ActivityTaskService> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<CreateActivityTaskResponse> CreateActivityAsync(CreateActivityTaskRequest request, CancellationToken cancellationToken)
        {
            CreateActivityTaskResponse response = new(request.CorrelationId());
            _logger.LogInformation($"Create activity task request correlation: {response.CorrelationId}");
            response.ActivityTaskCreated = await _repository.AddAsync(request.ActivityTask, cancellationToken);
            response.Message = "Activity task created success";
            _logger.LogInformation("Create successfull");
            return response;
        }

        public async Task<DeleteActivityTaskResponse> DeleteActivityAsync(DeleteActivityTaskRequest request, CancellationToken cancellationToken)
        {
            DeleteActivityTaskResponse response = new(request.CorrelationId());
            _logger.LogInformation($"delete activity task by id : {request.Id},  request correlation: {response.CorrelationId}");
            var TypeUserFound = await _repository.GetByIdAsync(request.Id, cancellationToken);
            response.ActivityTaskDeleted = await _repository.DeleteAsync(TypeUserFound, cancellationToken);
            response.Message = "Delete activity task success";
            _logger.LogInformation("Delete request successfull");
            return response;
        }

        public async Task<GetAllActivityTaskResponse> GetAllActivityAsync(GetAllActivityTaskRequest request, CancellationToken cancellationToken)
        {
            GetAllActivityTaskResponse response = new(request.CorrelationId());
            _logger.LogInformation($"Get all activity task,  request correlation: {response.CorrelationId}");
            response.ActivityTasks = await _repository.ListAsync(cancellationToken);
            response.Message = "GetAll activity task success";
            _logger.LogInformation("Get all request successfull");
            return response;
        }

        public async Task<UpdateActivityResponse> UpdateActivityAsync(UpdateActivityRequest request, CancellationToken cancellationToken)
        {
            UpdateActivityResponse response = new(request.CorrelationId());
            _logger.LogInformation($"Update activity task request correlation: {response.CorrelationId}");
            response.ActivityTaskUpdated = await _repository.UpdateAsync(request.ActivityTask, cancellationToken);
            response.Message = "Update activity task success";
            _logger.LogInformation("Updated successfull");
            return response;
        }
    }
}