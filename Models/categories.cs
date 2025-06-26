using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_Antivirus.Models;

public partial class categories
{
    [Key]
    public int id { get; set; }

    [StringLength(255)]
    public string name { get; set; } = null!;

    public string? description { get; set; }

    [InverseProperty("category")]
    public virtual ICollection<opportunities> opportunities { get; set; } = new List<opportunities>();
}
