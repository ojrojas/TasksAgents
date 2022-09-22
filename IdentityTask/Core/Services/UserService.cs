using IdentityTask.Core.Interfaces;

namespace IdentityTask.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _repository;
        private readonly ILogger<UserService> _logger;

        public UserService(IGenericRepository<User> repository, ILogger<UserService> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request, CancellationToken cancellationToken)
        {
            CreateUserResponse response = new(request.CorrelationId());
            _logger.LogInformation($"Create user request correlation: {response.CorrelationId}");
            response.UserCreated = await _repository.AddAsync(request.User, cancellationToken);
            response.Message = "User created success";
            _logger.LogInformation("Create successfull");
            return response;
        }

        public async Task<DeleteUserResponse> DeleteUserAsync(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            DeleteUserResponse response = new(request.CorrelationId());
            _logger.LogInformation($"delete user by id : {request.Id},  request correlation: {response.CorrelationId}");
            var userFound = await _repository.GetByIdAsync(request.Id, cancellationToken);
            response.UserDeleted = await _repository.DeleteAsync(userFound, cancellationToken);
            response.Message = "Delete user success";
            _logger.LogInformation("Delete request successfull");
            return response;
        }

        public async Task<GetAllUserResponse> GetAllUserAsync(GetAllUserRequest request, CancellationToken cancellationToken)
        {
            GetAllUserResponse response = new(request.CorrelationId());
            _logger.LogInformation($"Get all user request correlation: {response.CorrelationId}");
            response.Users = await _repository.ListAsync(cancellationToken);
            response.Message = "Get all users success";
            _logger.LogInformation("Get successfull");
            return response;
        }

        public async Task<GetUserByIdResponse> GetUserByIdAsync(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            GetUserByIdResponse response = new(request.CorrelationId());
            _logger.LogInformation($"Get user by id request correlation: {response.CorrelationId}");
            response.User = await _repository.GetByIdAsync(request.Id, cancellationToken);
            response.Message = "Get user by id success";
            _logger.LogInformation("Get successfull");
            return response;
        }

        public async Task<UpdateUserResponse> UpdateUserAsync(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            UpdateUserResponse response = new(request.CorrelationId());
            _logger.LogInformation($"Update user request correlation: {response.CorrelationId}");
            response.UserUpdated = await _repository.UpdateAsync(request.User, cancellationToken);
            response.Message = "Update user success";
            _logger.LogInformation("Updated successfull");
            return response;
        }
    }
}
