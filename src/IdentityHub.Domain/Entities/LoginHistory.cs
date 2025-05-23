namespace IdentityHub.Domain.Entities;

public class LoginHistory
{
    public Guid IdentificadorHistorico { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }

    public DateTime LoginDate { get; set; }
    public string IpAdress { get; set; }
    public bool IsSuccessful { get; set; }
}
