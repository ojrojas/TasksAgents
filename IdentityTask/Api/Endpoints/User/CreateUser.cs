namespace IdentityTask.Api.Endpoints
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CreateUser : EndpointBaseAsync.WithRequest<CreateUserRequest>.WithResult<CreateUserResponse>
    {
        private readonly IUserService _service;

        public CreateUser(IUserService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost]
        [Produces(typeof(CreateUserResponse))]
        [SwaggerOperation(
         Summary = "Create user",
         Description = "Create user",
         OperationId = "User.createuser",
         Tags = new[] { "UserEndpoints" })]
        public async override Task<CreateUserResponse> HandleAsync(CreateUserRequest request, CancellationToken cancellationToken = default)
        {
            return await _service.CreateUserAsync(request, cancellationToken);
        }
    }
}
