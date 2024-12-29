using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FakeBK.Models;

public partial class Student
{
    [Key]
    //[Range(1, 1000)]
    public decimal Id { get; set; }

    [Required]
    [Range(1,1000)]
    public decimal OrgpId { get; set; }
    [Required]
    [Range(1, 10)]
    public decimal ClassId { get; set; }


    public virtual Class? Class { get; set; } 

    public virtual Orgperson? Orgp { get; set; } 

    public virtual ICollection<Course>? Courses { get; set; } = new List<Course>();
}
