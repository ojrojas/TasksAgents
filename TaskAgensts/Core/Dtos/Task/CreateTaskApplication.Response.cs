namespace TaskAgents.Core.Dtos
{
    public class CreateTaskApplicationResponse: BaseResponse
    {
        public CreateTaskApplicationResponse(Guid CorrelationId): base(CorrelationId) { }
        public TaskApplication TaskApplicationCreated { get; set; }
    }
}
