namespace TaskAgents.Core.Entities
{
    public class TypeTask: BaseEntity, IAggregateRoot
    {
        public string TypeTaskName { get; set; }
    }
}
