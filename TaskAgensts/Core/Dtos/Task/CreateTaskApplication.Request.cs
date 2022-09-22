namespace TaskAgents.Core.Dtos
{
    public class CreateTaskApplicationRequest: BaseRequest 
    {
        public TaskApplication  TaskApplication { get; set; }
    }
}
