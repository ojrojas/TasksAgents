namespace IdentityTask.Api.Endpoints
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UpdateUserApplication: EndpointBaseAsync.WithRequest<UpdateUserApplicationRequest>.WithResult<UpdateUserApplicationResponse>
    {
        private readonly IUserApplicationService _service;

        public UpdateUserApplication(IUserApplicationService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPatch]
        [Produces(typeof(UpdateUserApplicationResponse))]
        [SwaggerOperation(
         Summary = "Update user application",
         Description = "Update user application",
         OperationId = "userapplication.updateuserapplication",
         Tags = new[] { "UserEndpoints" })]
        public async override Task<UpdateUserApplicationResponse> HandleAsync(UpdateUserApplicationRequest request, CancellationToken cancellationToken = default)
        {
            return await _service.UpdateUserApplicationAsync(request, cancellationToken);
        }
    }
}
