namespace TaskAgents.Core.Dtos
{
    public class GetAllActivityTaskResponse : BaseResponse
    {
        public GetAllActivityTaskResponse(Guid CorrelationId): base(CorrelationId) { }
        public IReadOnlyList<ActivityTask> ActivityTasks { get; set; }
    }
}
