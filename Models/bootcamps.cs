using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_Antivirus.Models;

public partial class bootcamps
{
    [Key]
    public int id { get; set; }

    [StringLength(255)]
    public string name { get; set; } = null!;

    public string? description { get; set; }

    public string? information { get; set; }

    public string? costs { get; set; }

    public int? institution_id { get; set; }

    [InverseProperty("bootcamp")]
    public virtual ICollection<bootcamp_topics> bootcamp_topics { get; set; } = new List<bootcamp_topics>();

    [ForeignKey("institution_id")]
    [InverseProperty("bootcamps")]
    public virtual institutions? institution { get; set; }
}
