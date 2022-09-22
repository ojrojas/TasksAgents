namespace TaskAgents.Core.Dtos
{
    public class DeleteActivityTaskRequest: BaseRequest
    {
        public Guid Id { get; set; }
    }
}
