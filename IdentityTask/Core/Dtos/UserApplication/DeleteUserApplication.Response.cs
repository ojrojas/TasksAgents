namespace IdentityTask.Core.Dtos
{
    public class DeleteUserApplicationResponse: BaseResponse
    {
        public DeleteUserApplicationResponse(Guid CorrelationId): base(CorrelationId) { }
        public UserApplication UserDeleted { get; set; }
    }
}
