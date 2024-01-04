using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Manager.Admin;

public class AdminRefreshToken
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string Token { get; set; }
    public DateTime ExpireAt { get; set; }
    
    public AdminID AdminId { get; set; }
    public Admin Admin { get; set; }
    
    
}