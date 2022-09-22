namespace TaskAgents.Core.Entities
{
    public class ActivityTask : BaseEntity, IAggregateRoot
    {
        public string NameActivity { get; set; }
    }
}
