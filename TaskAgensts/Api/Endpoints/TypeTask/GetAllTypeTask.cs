namespace TaskAgents.Api.Endpoints
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class GetAllTypeTask : EndpointBaseAsync.WithoutRequest.WithResult<GetAllTypeTaskResponse>
    {
        private readonly ITypeTaskService _service;

        public GetAllTypeTask(ITypeTaskService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        [Produces(typeof(GetAllActivityTaskResponse))]
        [SwaggerOperation(
        Summary = "Get all type task",
        Description = "Get all type tasl",
        OperationId = "typetask.getalltypetask",
        Tags = new[] { "TypeTaskEndpoints" })]
        public override async Task<GetAllTypeTaskResponse> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await _service.GetAllTypeTaskAsync(new(), cancellationToken);
        }
    }
}
