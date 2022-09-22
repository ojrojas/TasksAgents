namespace TaskAgents.Api.Endpoints
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DeleteTaskApplication : EndpointBaseAsync.WithRequest<DeleteTaskApplicationRequest>.WithResult<DeleteTaskApplicationResponse>
    {
        private readonly ITaskApplicationService _service;

        public DeleteTaskApplication(ITaskApplicationService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpDelete("{Id}")]
        [Produces(typeof(DeleteTaskApplicationResponse))]
        [SwaggerOperation(
        Summary = "Delete task application",
        Description = "Delete task application",
        OperationId = "taskapplication.Deletetaskapplication",
        Tags = new[] { "TaskApplicationEndpoints" })]
        public override async Task<DeleteTaskApplicationResponse> HandleAsync([FromRoute]DeleteTaskApplicationRequest request, CancellationToken cancellationToken = default)
        {
            return await _service.DeleteTaskApplicationAsync(request, cancellationToken);
        }
    }
}
