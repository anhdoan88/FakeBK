using System;
using System.Collections.Generic;

namespace FakeBK.Models;

public partial class Department
{
    public decimal Id { get; set; }

    public decimal? HeadteachId { get; set; }

    public virtual ICollection<Course>? Courses { get; set; } = new List<Course>();

    public virtual Teacher? Headteach { get; set; }

    public virtual ICollection<Teacher>? Teachers { get; set; } = new List<Teacher>();
}
