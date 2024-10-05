using StudentAPI_BE.Models;

namespace StudentAPI_BE.Dtos;

public class StudentDTO
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Address { get; set; }

    public string Phone { get; set; }

    public string Dob { get; set; }

    //public int CourseId { get; set; }

    //public string CourseName { get; set; }
}
