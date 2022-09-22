namespace TaskAgents.Core.Dtos
{
    public class GetTaskApplicationByIdResponse: BaseResponse
    {
        public GetTaskApplicationByIdResponse(Guid CorrelationId): base(CorrelationId) { }
        public TaskApplication TaskApplication { get; set; }
    }
}
