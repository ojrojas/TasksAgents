namespace IdentityTask.Api.Endpoints
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class GetUserApplicationById : EndpointBaseAsync.WithRequest<GetUserApplicationByIdRequest>.WithResult<GetUserApplicationByIdResponse>
    {
        private readonly IUserApplicationService _service;

        public GetUserApplicationById(IUserApplicationService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet("{Id}")]
        [Produces(typeof(GetUserApplicationByIdResponse))]
        [SwaggerOperation(
         Summary = "get user application by id",
         Description = "get user application by id",
         OperationId = "userapplication.getuserapplicationbyid",
         Tags = new[] { "UserApplicationEndpoints" })]
        public async override Task<GetUserApplicationByIdResponse> HandleAsync(GetUserApplicationByIdRequest request, CancellationToken cancellationToken = default)
        {
            return await _service.GetUserApplicationByIdAsync(request, cancellationToken);
        }
    }
}
