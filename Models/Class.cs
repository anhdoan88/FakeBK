using System;
using System.Collections.Generic;

namespace FakeBK.Models;

public partial class Class
{
    public decimal Id { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Teachclass> Teachclasses { get; set; } = new List<Teachclass>();
}
