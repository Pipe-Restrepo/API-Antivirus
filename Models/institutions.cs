using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_Antivirus.Models;

public partial class institutions
{
    [Key]
    public int id { get; set; }

    [StringLength(255)]
    public string name { get; set; } = null!;

    public string? ubication { get; set; }

    public string? url_generalidades { get; set; }

    public string? url_oferta_academica { get; set; }

    public string? url_bienestar { get; set; }

    public string? url_admision { get; set; }
    [Required, MaxLength(1000)]
    public string logo { get; set; }

    [InverseProperty("institution")]
    public virtual ICollection<bootcamps> bootcamps { get; set; } = new List<bootcamps>();

    [InverseProperty("institution")]
    public virtual ICollection<opportunities> opportunities { get; set; } = new List<opportunities>();
}
