namespace StudentAPI_BE.Dtos;

public class CourseDTO
{
    public int CourseId { get; set; }

    public string CourseName { get; set; }

    public decimal? CourseScore { get; set; }

    public int StudentId { get; set; }
}
