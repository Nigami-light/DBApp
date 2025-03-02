using System;
using System.Collections.Generic;

namespace DBApp.Entities;

public partial class Groupe
{
    public int GroupId { get; set; }

    public string GroupName { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
