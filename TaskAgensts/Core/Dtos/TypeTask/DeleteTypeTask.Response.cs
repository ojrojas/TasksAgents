namespace TaskAgents.Core.Dtos
{
    public class DeleteTypeTaskResponse:BaseResponse
    {
        public DeleteTypeTaskResponse(Guid CorrelationId): base(CorrelationId) { }
        public TypeTask TypeTaskDeleted { get; set; }
    }
}
