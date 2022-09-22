namespace TaskAgents.Core.Dtos
{
    public class GetTaskApplicationByIdRequest: BaseRequest
    {
        public Guid Id { get; set; }
    }
}
