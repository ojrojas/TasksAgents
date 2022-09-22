namespace TaskAgents.Core.Entities
{
    public class TaskApplication : BaseEntity, IAggregateRoot
    {
        public string TaskName { get; set; }
        public DateTime TimeTask { get; set; }
        public string Comments { get; set; }
        public Guid ActivityTaskId { get; set; }
        public ActivityTask ActivityTask { get; set; }
        public Guid TypeTaskId { get; set; }
        public TypeTask TypeTask { get; set; }
        public Guid AgentId { get; set; }
        public string AgentFullName { get; set; }
    }
}