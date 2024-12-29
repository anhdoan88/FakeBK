using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FakeBK.Models;

public partial class Teacher
{
    [Key]
    public decimal Id { get; set; }
    [Required]
    [Range(1, 1000)]
    public decimal? OrgpId { get; set; }
    [Required]
    [Range(1, 10)]
    public decimal? DeptId { get; set; }

    public virtual ICollection<Department>? Departments { get; set; } = new List<Department>();

    public virtual Department? Dept { get; set; }

    public virtual Orgperson? Orgp { get; set; } 

    public virtual ICollection<Teachclass>? Teachclasses { get; set; } = new List<Teachclass>();
}
