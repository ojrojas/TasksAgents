namespace TaskAgents.Core.Dtos
{
    public class CreateActivityTaskRequest : BaseRequest
    {
        public ActivityTask ActivityTask { get; set; }
    }
}
