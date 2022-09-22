namespace TaskAgents.Core.Dtos
{
    public class GetAllTaskApplicationResponse: BaseResponse
    {
        public GetAllTaskApplicationResponse(Guid CorrelationId): base(CorrelationId) { }
        public IEnumerable<TaskApplication> TaskApplications { get; set; }
    }
}
