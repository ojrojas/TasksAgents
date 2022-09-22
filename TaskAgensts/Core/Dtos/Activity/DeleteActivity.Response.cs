namespace TaskAgents.Core.Dtos
{
    public class DeleteActivityTaskResponse :BaseResponse
    {
        public DeleteActivityTaskResponse(Guid CorrelationId): base(CorrelationId) { }
        public ActivityTask ActivityTaskDeleted { get; set; }
    }
}
