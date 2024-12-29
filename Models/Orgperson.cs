using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FakeBK.Models;


public partial class Orgperson
{
    public decimal Id { get; set; }
    [Required]
   
    public virtual ICollection<Relative> Relatives { get; set; } = new List<Relative>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
