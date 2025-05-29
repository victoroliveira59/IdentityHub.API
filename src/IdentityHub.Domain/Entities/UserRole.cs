using System.ComponentModel.DataAnnotations;

namespace IdentityHub.Domain.Entities;

public class UserRole
{
    [Key]
    public Guid IdentificadorUserRole { get; set; }

    public User User { get; set; }

    public Guid RoleId { get; set; }

    public Role Role { get; set; } 
}
