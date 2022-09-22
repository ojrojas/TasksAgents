namespace IdentityTask.Core.Dtos
{
    public class GetUserApplicationByIdResponse: BaseResponse
    {
        public GetUserApplicationByIdResponse(Guid CorrelationId): base(CorrelationId) { }
        public UserApplication UserApplication { get; set; }
    }
}
