namespace TaskAgents.Api.Endpoints
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CreateTypeTask : EndpointBaseAsync.WithRequest<CreateTypeTaskRequest>.WithResult<CreateTypeTaskResponse>
    {
        private readonly ITypeTaskService _service;

        public CreateTypeTask(ITypeTaskService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost]
        [Produces(typeof(CreateTypeTaskResponse))]
        [SwaggerOperation(
           Summary = "Create type task",
           Description = "Create type task",
           OperationId = "typetask.createtypetask",
           Tags = new[] { "TypeTaskEndpoints" })]
        public override async Task<CreateTypeTaskResponse> HandleAsync(CreateTypeTaskRequest request, CancellationToken cancellationToken = default)
        {
            return await _service.CreateTypeTaskAsync(request, cancellationToken);
        }
    }
}
