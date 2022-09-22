namespace IdentityTask.Core.Services
{
    public class TypeUserService : ITypeUserService
    {
        private readonly IGenericRepository<TypeUser> _repository;
        private readonly ILogger<TypeUserService> _logger;

        public TypeUserService(IGenericRepository<TypeUser> repository, ILogger<TypeUserService> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<CreateTypeUserResponse> CreateTypeUserAsync(CreateTypeUserRequest request, CancellationToken cancellationToken)
        {
            CreateTypeUserResponse response = new(request.CorrelationId());
            _logger.LogInformation($"Create TypeUser request correlation: {response.CorrelationId}");
            response.TypeUserCreated = await _repository.AddAsync(request.TypeUser, cancellationToken);
            response.Message = "TypeUser created success";
            _logger.LogInformation("Create successfull");
            return response;
        }

        public async Task<DeleteTypeUserResponse> DeleteTypeUserAsync(DeleteTypeUserRequest request, CancellationToken cancellationToken)
        {
            DeleteTypeUserResponse response = new(request.CorrelationId());
            _logger.LogInformation($"delete TypeUser by id : {request.Id},  request correlation: {response.CorrelationId}");
            var TypeUserFound = await _repository.GetByIdAsync(request.Id, cancellationToken);
            response.TypeUserDeleted = await _repository.DeleteAsync(TypeUserFound, cancellationToken);
            response.Message = "Delete TypeUser success";
            _logger.LogInformation("Delete request successfull");
            return response;
        }

        public async Task<GetAllTypeUserResponse> GetAllTypeUserAsync(GetAllTypeUserRequest request, CancellationToken cancellationToken)
        {
            GetAllTypeUserResponse response = new(request.CorrelationId());
            _logger.LogInformation($"Get all TypeUser request correlation: {response.CorrelationId}");
            response.TypeUsers = await _repository.ListAsync(cancellationToken);
            response.Message = "TypeUser get success";
            _logger.LogInformation("Get all successfull");
            return response;
        }

        public async Task<UpdateTypeUserResponse> UpdateTypeUserAsync(UpdateTypeUserRequest request, CancellationToken cancellationToken)
        {
            UpdateTypeUserResponse response = new(request.CorrelationId());
            _logger.LogInformation($"Update TypeUser request correlation: {response.CorrelationId}");
            response.TypeUserUpdated = await _repository.UpdateAsync(request.TypeUser, cancellationToken);
            response.Message = "Update TypeUser success";
            _logger.LogInformation("Updated successfull");
            return response;
        }
    }
}
