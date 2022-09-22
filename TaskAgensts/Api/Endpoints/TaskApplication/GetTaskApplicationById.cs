namespace TaskAgents.Api.Endpoints
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class GetTaskApplicationById : EndpointBaseAsync.WithRequest<GetTaskApplicationByIdRequest>.WithResult<GetTaskApplicationByIdResponse>
    {
        private readonly ITaskApplicationService _service;

        public GetTaskApplicationById(ITaskApplicationService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet("{Id}")]
        [Produces(typeof(GetAllTaskApplicationResponse))]
        [SwaggerOperation(
            Summary = "Get task application by id",
            Description = "Get task application by id",
            OperationId = "taskapplication.gettaskapplicationbyid",
            Tags = new[] { "TaskApplicationEndpoints" })]
        public override async Task<GetTaskApplicationByIdResponse> HandleAsync([FromRoute]GetTaskApplicationByIdRequest request, CancellationToken cancellationToken = default)
        {
            return await _service.GetTaskApplicationByIdAsync(request, cancellationToken);
        }
    }
}
