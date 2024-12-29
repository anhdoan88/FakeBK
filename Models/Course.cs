using System;
using System.Collections.Generic;

namespace FakeBK.Models;

public partial class Course
{
    public decimal Id { get; set; }

    public string? Name { get; set; }

    public decimal? DeptId { get; set; }

    public virtual Department? Dept { get; set; }

    public virtual ICollection<Teachclass> Teachclasses { get; set; } = new List<Teachclass>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
