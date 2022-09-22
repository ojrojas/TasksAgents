namespace TaskAgents.Api.Endpoints
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UpdateTaskApplication : EndpointBaseAsync.WithRequest<UpdateTaskApplicationRequest>.WithResult<UpdateTaskApplicationResponse>
    {
        private readonly ITaskApplicationService _service;

        public UpdateTaskApplication(ITaskApplicationService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPatch]
        [Produces(typeof(UpdateTaskApplicationResponse))]
        [SwaggerOperation(
        Summary = "Update task application",
        Description = "Update task application",
        OperationId = "taskapplication.Updatetaskapplication",
        Tags = new[] { "TaskApplicationEndpoints" })]
        public override async Task<UpdateTaskApplicationResponse> HandleAsync(UpdateTaskApplicationRequest request, CancellationToken cancellationToken = default)
        {
            return await _service.UpdateTaskApplicationAsync(request, cancellationToken);
        }
    }
}
