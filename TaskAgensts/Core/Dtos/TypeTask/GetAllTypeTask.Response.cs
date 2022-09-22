namespace TaskAgents.Core.Dtos
{
    public class GetAllTypeTaskResponse : BaseResponse
    {
        public GetAllTypeTaskResponse(Guid CorrelationId): base(CorrelationId) { }
        public IReadOnlyList<TypeTask> TypeTasks { get; set; }
    }
}
