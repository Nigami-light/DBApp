using System;
using System.Collections.Generic;

namespace DBApp.Entities;

public partial class Teacher
{
    public int TeacherId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
