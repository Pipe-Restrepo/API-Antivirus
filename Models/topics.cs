using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_Antivirus.Models;

public partial class topics
{
    [Key]
    public int id { get; set; }

    [StringLength(255)]
    public string name { get; set; } = null!;

    [InverseProperty("topic")]
    public virtual ICollection<bootcamp_topics> bootcamp_topics { get; set; } = new List<bootcamp_topics>();
}
