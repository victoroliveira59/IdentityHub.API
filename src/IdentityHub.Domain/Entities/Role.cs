using System.ComponentModel.DataAnnotations;

namespace IdentityHub.Domain.Entities;

public class Role
{
    [Key]
    public Guid IdentificadorRole { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
