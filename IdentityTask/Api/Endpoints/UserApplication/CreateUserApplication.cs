namespace IdentityTask.Api.Endpoints
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CreateUserApplication : EndpointBaseAsync.WithRequest<CreateUserApplicationRequest>.WithResult<CreateUserApplicationResponse>
    {
        private readonly IUserApplicationService _service;

        public CreateUserApplication(IUserApplicationService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost]
        [Produces(typeof(CreateUserApplicationResponse))]
        [SwaggerOperation(
         Summary = "Create user application",
         Description = "Create user application",
         OperationId = "userapplication.createuserapplication",
         Tags = new[] { "UserApplicationEndpoints" })]
        public async override Task<CreateUserApplicationResponse> HandleAsync(CreateUserApplicationRequest request, CancellationToken cancellationToken = default)
        {
            return await _service.CreateUserApplicationAsync(request, cancellationToken);
        }
    }
}
