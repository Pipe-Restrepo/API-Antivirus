using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_Antivirus.Models;

public partial class user_opportunities
{
    [Key]
    public int id { get; set; }

    public int user_id { get; set; }

    public int opportunity_id { get; set; }

    [ForeignKey("opportunity_id")]
    [InverseProperty("user_opportunities")]
    public virtual opportunities opportunity { get; set; } = null!;

    [ForeignKey("user_id")]
    [InverseProperty("user_opportunities")]
    public virtual users user { get; set; } = null!;
}
