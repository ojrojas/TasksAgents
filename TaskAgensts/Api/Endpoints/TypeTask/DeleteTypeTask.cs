namespace TaskAgents.Api.Endpoints
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DeleteTypeTask : EndpointBaseAsync.WithRequest<DeleteTypeTaskRequest>.WithResult<DeleteTypeTaskResponse>
    {
        private readonly ITypeTaskService _service;

        public DeleteTypeTask(ITypeTaskService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpDelete("{Id}")]
        [Produces(typeof(DeleteTypeTaskResponse))]
        [SwaggerOperation(
          Summary = "Delete type task",
          Description = "Delete type task",
          OperationId = "typetask.deletetypetask",
          Tags = new[] { "TypeTaskEndpoints" })]
        public override async Task<DeleteTypeTaskResponse> HandleAsync(DeleteTypeTaskRequest request, CancellationToken cancellationToken = default)
        {
            return await _service.DeleteTypeTaskAsync(request, cancellationToken);
        }
    }
}
