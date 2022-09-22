namespace IdentityTask.Api.Endpoints
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class GetUserById : EndpointBaseAsync.WithRequest<GetUserByIdRequest>.WithResult<GetUserByIdResponse>
    {
        private readonly IUserService _service;

        public GetUserById(IUserService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet("{Id}")]
        [Produces(typeof(GetUserByIdResponse))]
        [SwaggerOperation(
         Summary = "Get user by id",
         Description = "get user by id",
         OperationId = "User.getuserbyid",
         Tags = new[] { "UserEndpoints" })]
        public async override Task<GetUserByIdResponse> HandleAsync([FromRoute]GetUserByIdRequest request, CancellationToken cancellationToken = default)
        {
            return await _service.GetUserByIdAsync(request, cancellationToken);
        }
    }
}
