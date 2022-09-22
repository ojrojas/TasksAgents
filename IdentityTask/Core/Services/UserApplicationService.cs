namespace IdentityTask.Core.Services
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IGenericRepository<UserApplication> _repository;
        private readonly ILogger<UserApplicationService> _logger;
        private readonly IEncryptService _encryptService;
        private readonly ITokenClaimService _tokenClaimService;

        public UserApplicationService(IGenericRepository<UserApplication> repository, ILogger<UserApplicationService> logger, IEncryptService encryptService, ITokenClaimService tokenClaimService)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _encryptService = encryptService ?? throw new ArgumentNullException(nameof(encryptService));
            _tokenClaimService = tokenClaimService ?? throw new ArgumentNullException(nameof(tokenClaimService));
        }

        public async Task<CreateUserApplicationResponse> CreateUserApplicationAsync(CreateUserApplicationRequest request, CancellationToken cancellationToken)
        {
            request.UserApplication.Password = await _encryptService.Encrypt(request.UserApplication.Password);
            CreateUserApplicationResponse response = new(request.CorrelationId());
            _logger.LogInformation($"Create user application request correlation: {response.CorrelationId}");
            response.UserApplicationCreated = await _repository.AddAsync(request.UserApplication, cancellationToken);
            response.Message = "User created success";
            _logger.LogInformation("Create successfull");
            return response;
        }

        public async Task<GetUserApplicationByIdResponse> GetUserApplicationByIdAsync(GetUserApplicationByIdRequest request, CancellationToken cancellationToken)
        {
            GetUserApplicationByIdResponse response = new(request.CorrelationId());
            _logger.LogInformation($"get user application by id : {request.Id},  request correlation: {response.CorrelationId}");
            response.UserApplication = await _repository.GetByIdAsync(request.Id, cancellationToken);
            response.Message = "Get user success";
            _logger.LogInformation("Get request successfull");
            return response;
        }

        public async Task<DeleteUserApplicationResponse> DeleteUserApplicationAsync(DeleteUserApplicationRequest request, CancellationToken cancellationToken)
        {
            DeleteUserApplicationResponse response = new(request.CorrelationId());
            _logger.LogInformation($"delete user application by id : {request.Id},  request correlation: {response.CorrelationId}");
            var userFound = await _repository.GetByIdAsync(request.Id, cancellationToken);
            response.UserDeleted = await _repository.DeleteAsync(userFound, cancellationToken);
            response.Message = "Delete user success";
            _logger.LogInformation("Delete request successfull");
            return response;
        }

        public async Task<UpdateUserApplicationResponse> UpdateUserApplicationAsync(UpdateUserApplicationRequest request, CancellationToken cancellationToken)
        {
            request.UserApplication.Password = await _encryptService.Encrypt(request.UserApplication.Password);
            UpdateUserApplicationResponse response = new(request.CorrelationId());
            _logger.LogInformation($"Update user application,  request correlation: {response.CorrelationId}");
            response.UserApplicationUpdated = await _repository.UpdateAsync(request.UserApplication, cancellationToken);
            response.Message = "Update user success";
            _logger.LogInformation("Update request successfull");
            return response;
        }

        public async Task<LoginUserApplicationResponse> LoginUserApplicationAsync(LoginUserApplicationRequest request, CancellationToken cancellationToken)
        {
            request.Password = await _encryptService.Encrypt(request.Password);
            LoginUserApplicationResponse response = new(request.CorrelationId());
            _logger.LogInformation($"login user application,  request correlation: {response.CorrelationId}");
            UserApplicationSpecification specification = new(request.UserName, request.Password);
            var userApplication = await _repository.FirstOrDefaultAsync(specification, cancellationToken);
            if (userApplication is not null)
                response.Token = await _tokenClaimService.GetTokenAsync(userApplication.User);
            return response;
        }
    }
}
