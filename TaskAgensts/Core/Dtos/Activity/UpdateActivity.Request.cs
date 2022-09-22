namespace TaskAgents.Core.Dtos
{
    public class UpdateActivityRequest: BaseRequest
    {
        public ActivityTask ActivityTask { get; set; }
    }
}
