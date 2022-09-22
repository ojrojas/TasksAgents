namespace TaskAgents.Api.Endpoints
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DeleteActivityTask : EndpointBaseAsync.WithRequest<DeleteActivityTaskRequest>.WithResult<DeleteActivityTaskResponse>
    {
        private readonly IActivityTaskService _service;

        public DeleteActivityTask(IActivityTaskService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpDelete("{Id}")]
        [Produces(typeof(DeleteActivityTaskResponse))]
        [SwaggerOperation(
           Summary = "Delete activity task",
           Description = "Delete activity tasl",
           OperationId = "activitytask.deleteactivitytask",
           Tags = new[] { "ActivityTaskEndpoints" })]
        public override async Task<DeleteActivityTaskResponse> HandleAsync(DeleteActivityTaskRequest request, CancellationToken cancellationToken = default)
        {
            return await _service.DeleteActivityAsync(request, cancellationToken);
        }
    }
}
