using System.ComponentModel.DataAnnotations;

namespace TaskAgents.Core.Entities;

public class BaseEntity : IAggregateRoot
{
    [Key]
    public Guid Id { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public Guid ModifiedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public bool State { get; set; } = true;
}
