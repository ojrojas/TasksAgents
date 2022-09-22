namespace TaskAgents.Api.Endpoints
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetAllActivityTask : EndpointBaseAsync.WithoutRequest.WithResult<GetAllActivityTaskResponse>
    {

        private readonly IActivityTaskService _service;

        public GetAllActivityTask(IActivityTaskService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        [Produces(typeof(GetAllActivityTaskResponse))]
        [SwaggerOperation(
         Summary = "Get all activity task",
         Description = "Get all activity tasl",
         OperationId = "activitytask.getallactivitytask",
         Tags = new[] { "ActivityTaskEndpoints" })]
        public override async Task<GetAllActivityTaskResponse> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await _service.GetAllActivityAsync(new(), cancellationToken);
        }
    }
}
