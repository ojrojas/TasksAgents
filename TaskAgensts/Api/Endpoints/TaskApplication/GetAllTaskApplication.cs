namespace TaskAgents.Api.Endpoints
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class GetAllTaskApplication : EndpointBaseAsync.WithoutRequest.WithResult<GetAllTaskApplicationResponse>
    {
        private readonly ITaskApplicationService _service;

        public GetAllTaskApplication(ITaskApplicationService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        [Produces(typeof(GetAllTaskApplicationResponse))]
        [SwaggerOperation(
        Summary = "GetAll task application",
        Description = "GetAll task application",
        OperationId = "taskapplication.GetAlltaskapplication",
        Tags = new[] { "TaskApplicationEndpoints" })]
        public override async Task<GetAllTaskApplicationResponse> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await _service.GetAllTaskApplicationAsync(new(), cancellationToken);
        }
    }
}