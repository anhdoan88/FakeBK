using System;
using System.Collections.Generic;

namespace FakeBK.Models;

public partial class Teachclass
{
    public decimal ClassId { get; set; }

    public decimal TeacherId { get; set; }

    public decimal CourseId { get; set; }

    public virtual Class? Class { get; set; } 

    public virtual Course? Course { get; set; } 

    public virtual Teacher? Teacher { get; set; } 
}
