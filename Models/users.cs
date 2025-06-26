using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_Antivirus.Models;

[Index("email", Name = "users_email_key", IsUnique = true)]
public partial class users
{
    [Key]
    public int id { get; set; }

    [StringLength(255)]
    public string name { get; set; } = null!;

    [StringLength(255)]
    public string email { get; set; } = null!;

    [StringLength(255)]
    public string password { get; set; } = null!;

    [StringLength(50)]
    public string rol { get; set; } = null!;

    [InverseProperty("user")]
    public virtual ICollection<user_opportunities> user_opportunities { get; set; } = new List<user_opportunities>();
}
