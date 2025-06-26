using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_Antivirus.Models;

public partial class bootcamp_topics
{
    [Key]
    public int id { get; set; }

    public int bootcamp_id { get; set; }

    public int topic_id { get; set; }

    [ForeignKey("bootcamp_id")]
    [InverseProperty("bootcamp_topics")]
    public virtual bootcamps bootcamp { get; set; } = null!;

    [ForeignKey("topic_id")]
    [InverseProperty("bootcamp_topics")]
    public virtual topics topic { get; set; } = null!;
}
