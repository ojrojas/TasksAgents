namespace TaskAgents.Core.Dtos
{
    public class UpdateTaskApplicationResponse: BaseResponse
    {
        public UpdateTaskApplicationResponse(Guid CorrelationId): base(CorrelationId) { }
        public TaskApplication TaskApplicationUpdated { get; set; }
    }
}
