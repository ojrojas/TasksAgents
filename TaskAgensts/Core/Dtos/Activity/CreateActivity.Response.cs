namespace TaskAgents.Core.Dtos
{
    public class CreateActivityTaskResponse: BaseResponse 
    {
        public CreateActivityTaskResponse(Guid CorrelationId) : base(CorrelationId) { }
        public ActivityTask ActivityTaskCreated { get; set; }
    }
}
