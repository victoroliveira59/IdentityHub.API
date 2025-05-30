using System.ComponentModel.DataAnnotations;

namespace IdentityHub.Domain.Entities;

public class LoginHistory
{
    [Key]
    public Guid IdentificadorHistorico { get; set; }
    public User User { get; set; }          
    public DateTime LoginDate { get; set; }
    public string IpAdress { get; set; }
    public bool IsSuccessful { get; set; }
}
