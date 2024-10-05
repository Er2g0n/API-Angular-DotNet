using System;
using System.Collections.Generic;

namespace StudentAPI_BE.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public DateTime Dob { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
