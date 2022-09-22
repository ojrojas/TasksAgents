namespace TaskAgents.Api.Endpoints
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UpdateActivityTask : EndpointBaseAsync.WithRequest<UpdateActivityRequest>.WithResult<UpdateActivityResponse>
    {
        private readonly IActivityTaskService _service;

        public UpdateActivityTask(IActivityTaskService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPatch]
        [Produces(typeof(UpdateActivityResponse))]
        [SwaggerOperation(
          Summary = "Update activity task",
          Description = "Update activity tasl",
          OperationId = "activitytask.updateactivitytask",
          Tags = new[] { "ActivityTaskEndpoints" })]
        public override async Task<UpdateActivityResponse> HandleAsync(UpdateActivityRequest request, CancellationToken cancellationToken = default)
        {
            return await _service.UpdateActivityAsync(request, cancellationToken);
        }
    }
}
