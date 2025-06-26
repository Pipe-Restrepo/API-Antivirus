using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_Antivirus.Models;

public partial class opportunities
{
    [Key]
    public int id { get; set; }

    [StringLength(255)]
    public string name { get; set; } = null!;

    public string? observation { get; set; }

    [StringLength(50)]
    public string? type { get; set; }

    public string? description { get; set; }

    public string? requires { get; set; }

    public string? guide { get; set; }

    public string? adicional_dates { get; set; }

    public string? service_channels { get; set; }

    [StringLength(255)]
    public string? manager { get; set; }

    [StringLength(50)]
    public string? modality { get; set; }
   
    public int? category_id { get; set; }

    public int? institution_id { get; set; }

    [ForeignKey("category_id")]
    [InverseProperty("opportunities")]
    public virtual categories? category { get; set; }

    [ForeignKey("institution_id")]
    [InverseProperty("opportunities")]
    public virtual institutions? institution { get; set; }

    [InverseProperty("opportunity")]
    public virtual ICollection<user_opportunities> user_opportunities { get; set; } = new List<user_opportunities>();
}
