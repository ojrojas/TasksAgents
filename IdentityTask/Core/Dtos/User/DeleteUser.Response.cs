namespace IdentityTask.Core.Dtos
{
    public class DeleteUserResponse: BaseResponse
    {
        public DeleteUserResponse(Guid CorrelationId): base(CorrelationId) { }
        public User UserDeleted { get; set; }
    }
}
