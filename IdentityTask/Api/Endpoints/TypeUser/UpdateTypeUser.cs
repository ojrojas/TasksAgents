﻿namespace IdentityTask.Api.Endpoints
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UpdateTypeUser : EndpointBaseAsync.WithRequest<UpdateTypeUserRequest>.WithResult<UpdateTypeUserResponse>
    {
        private readonly ITypeUserService _service;

        public UpdateTypeUser(ITypeUserService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPatch]
        [Produces(typeof(UpdateTypeUserResponse))]
        [SwaggerOperation(
         Summary = "Update type user",
         Description = "Update type user",
         OperationId = "typeuser.updatetypeuser",
         Tags = new[] { "TypeUserEndpoints" })]
        public async override Task<UpdateTypeUserResponse> HandleAsync(UpdateTypeUserRequest request, CancellationToken cancellationToken = default)
        {
            return await _service.UpdateTypeUserAsync(request, cancellationToken);
        }
    }
}
