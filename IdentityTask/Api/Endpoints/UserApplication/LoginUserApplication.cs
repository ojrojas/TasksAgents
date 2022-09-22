namespace IdentityTask.Api.Endpoints.UserApplication
{
    [ApiController]
    [Route("api/login")]
    public class LoginUserApplication : EndpointBaseAsync.WithRequest<LoginUserApplicationRequest>.WithResult<LoginUserApplicationResponse>
    {
        private readonly IUserApplicationService _service;

        public LoginUserApplication(IUserApplicationService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost]
        [Produces(typeof(GetUserApplicationByIdResponse))]
        [SwaggerOperation(
        Summary = "login user application by id",
        Description = "login user application by id",
        OperationId = "userapplication.loginuserapplicationbyid",
        Tags = new[] { "UserApplicationEndpoints" })]
        public override async Task<LoginUserApplicationResponse> HandleAsync(LoginUserApplicationRequest request, CancellationToken cancellationToken = default)
        {
           return await _service.LoginUserApplicationAsync(request, cancellationToken);
        }
    }
}
