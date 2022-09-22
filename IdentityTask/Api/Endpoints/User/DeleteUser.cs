﻿namespace IdentityTask.Api.Endpoints
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DeleteUser : EndpointBaseAsync.WithRequest<DeleteUserRequest>.WithResult<DeleteUserResponse>
    {
        private readonly IUserService _service;

        public DeleteUser(IUserService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpDelete("{Id}")]
        [Produces(typeof(DeleteUserResponse))]
        [SwaggerOperation(
         Summary = "Delete user",
         Description = "Delete user",
         OperationId = "User.deleteuser",
         Tags = new[] { "UserEndpoints" })]
        public async override Task<DeleteUserResponse> HandleAsync([FromRoute]DeleteUserRequest request, CancellationToken cancellationToken = default)
        {
            return await _service.DeleteUserAsync(request, cancellationToken);
        }
    }
}
