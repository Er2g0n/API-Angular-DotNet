using StudentAPI_BE.Dtos;

namespace StudentAPI_BE.Services;

public interface CourseService
{
    public CourseDTO findCourseById(int courseID);
    public List<CourseDTO> findAllCourse();
    public List<CourseDTO> findAllCourseByStudentId(int id);
    public List<CourseDTO> findCourseByKeywordDTO(String keyword);
    public List<CourseDTO> findCourseByScoreDTO(int score);
    public bool create(CourseDTO courseDTO);
    public bool update(CourseDTO courseDTO);
    public bool delete(int courseId);


}
