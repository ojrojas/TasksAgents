namespace TaskAgents.Core.Dtos
{
    public class UpdateActivityResponse : BaseResponse
    {
        public UpdateActivityResponse(Guid CorrelationId) : base(CorrelationId) { }
        public ActivityTask ActivityTaskUpdated { get; set; }
    }
}
