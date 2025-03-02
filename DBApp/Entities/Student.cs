using System;
using System.Collections.Generic;

namespace DBApp.Entities;

public partial class Student
{
    public int StudentId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly? BirthDate { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Groupe> Groups { get; set; } = new List<Groupe>();
}
