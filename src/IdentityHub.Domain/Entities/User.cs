namespace IdentityHub.Domain.Entities;

class User
{
    public Guid IdentificadorUsuario { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string PasswordSalt { get; set; }
    public bool IsActive { get; set; }
    public DateTime DataHoraCriacao { get; set; }
    public DateTime DataHoraUltimaAlteracao { get; set; }
    public DateTime DataHoraExclusao { get; set; }

    public  ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    public ICollection<LoginHistory> LoginHistories { get; set; } = new List<LoginHistory>();
}
