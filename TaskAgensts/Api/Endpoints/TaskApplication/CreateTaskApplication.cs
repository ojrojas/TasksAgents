namespace TaskAgents.Api.Endpoints
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CreateTaskApplication : EndpointBaseAsync.WithRequest<CreateTaskApplicationRequest>.WithResult<CreateTaskApplicationResponse>
    {
        private readonly ITaskApplicationService _service;

        public CreateTaskApplication(ITaskApplicationService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost]
        [Produces(typeof(CreateTaskApplicationResponse))]
        [SwaggerOperation(
        Summary = "Create task application",
        Description = "Create task application",
        OperationId = "taskapplication.createtaskapplication",
        Tags = new[] { "TaskApplicationEndpoints" })]
        public override async Task<CreateTaskApplicationResponse> HandleAsync(CreateTaskApplicationRequest request, CancellationToken cancellationToken = default)
        {
            return await _service.CreateTaskApplicationAsync(request, cancellationToken);
        }
    }
}
