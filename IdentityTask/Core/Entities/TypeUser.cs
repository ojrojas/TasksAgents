namespace IdentityTask.Core.Entities
{
    public class TypeUser : BaseEntity, IAggregateRoot
    {
        public string TypeName { get; set; }
    }
}
