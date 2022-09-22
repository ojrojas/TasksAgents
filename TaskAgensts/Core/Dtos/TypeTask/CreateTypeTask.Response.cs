namespace TaskAgents.Core.Dtos
{
    public class CreateTypeTaskResponse: BaseResponse
    {
        public CreateTypeTaskResponse(Guid CorrelationId): base(CorrelationId) { }
        public TypeTask TypeTaskCreated { get; set; }

    }
}
