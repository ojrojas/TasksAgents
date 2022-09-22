namespace IdentityTask.Core.Entities
{
    public  class User : BaseEntity, IAggregateRoot
    {
        public string FirstName { get; set; }
        public string Middlename { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
        public string Identification { get; set; }
        public Guid TypeUserId { get; set; }
        public TypeUser TypeUser { get; set; }
    }
}
