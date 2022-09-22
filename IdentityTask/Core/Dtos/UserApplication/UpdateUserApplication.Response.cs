namespace IdentityTask.Core.Dtos
{
    public class UpdateUserApplicationResponse: BaseResponse  
    {
        public UpdateUserApplicationResponse(Guid CorrelationId): base(CorrelationId) { }
        public UserApplication UserApplicationUpdated { get; set; }
    }
}
