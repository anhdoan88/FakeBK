using System;
using System.Collections.Generic;

namespace FakeBK.Models;

public partial class Relative
{
    public decimal OrgpId { get; set; }

    public string Name { get; set; } = null!;

    public virtual Orgperson Orgp { get; set; } = null!;
}
