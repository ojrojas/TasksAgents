namespace TaskAgents.Api.Endpoints
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CreateActivityTask : EndpointBaseAsync.WithRequest<CreateActivityTaskRequest>.WithResult<CreateActivityTaskResponse>
    {
        private readonly IActivityTaskService _service;

        public CreateActivityTask(IActivityTaskService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost]
        [Produces(typeof(CreateActivityTaskResponse))]
        [SwaggerOperation(
            Summary = "Create activity task",
            Description = "Create activity tasl",
            OperationId = "activitytask.createactivitytask",
            Tags = new[] { "ActivityTaskEndpoints" })]
        public override async Task<CreateActivityTaskResponse> HandleAsync(CreateActivityTaskRequest request, CancellationToken cancellationToken = default)
        {
            return await _service.CreateActivityAsync(request, cancellationToken);
        }
    }
}
