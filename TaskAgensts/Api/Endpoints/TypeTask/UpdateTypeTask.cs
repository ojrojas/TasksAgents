namespace TaskAgents.Api.Endpoints
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UpdateTypeTask : EndpointBaseAsync.WithRequest<UpdateTypeTaskRequest>.WithResult<UpdateTypeTaskResponse>
    {
        private readonly ITypeTaskService _service;

        public UpdateTypeTask(ITypeTaskService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPatch]
        [Produces(typeof(UpdateTypeTaskResponse))]
        [SwaggerOperation(
         Summary = "Update type task",
         Description = "Update type task",
         OperationId = "typetask.updatetypetask",
         Tags = new[] { "TypeTaskEndpoints" })]
        public override async Task<UpdateTypeTaskResponse> HandleAsync(UpdateTypeTaskRequest request, CancellationToken cancellationToken = default)
        {
            return await _service.UpdateTypeTaskAsync(request, cancellationToken);
        }
    }
}
