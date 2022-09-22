namespace TaskAgents.Core.Dtos
{
    public class UpdateTypeTaskResponse: BaseResponse
    {
        public UpdateTypeTaskResponse(Guid CorrelationId): base(CorrelationId) { }
        public TypeTask TypeTaskUpdated { get; set; }
    }
}
