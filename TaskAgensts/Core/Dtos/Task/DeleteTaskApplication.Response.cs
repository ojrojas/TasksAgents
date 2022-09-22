namespace TaskAgents.Core.Dtos
{
    public class DeleteTaskApplicationResponse: BaseResponse
    {
        public DeleteTaskApplicationResponse(Guid CorrelationId): base(CorrelationId) { }
        public TaskApplication TaskApplicationDeleted { get; set; }
    }
}
