using StudentAPI_BE.Dtos;

namespace StudentAPI_BE.Services;

public interface StudentService
{
    public StudentDTO findStudentById(int studentId);
    public List<StudentDTO> findAllStudents();
    public bool Create(StudentDTO studentDTO);
    public bool Update(StudentDTO studentDTO);
    public bool Delete(int studentId);
    public List<StudentDTO> findStudentByKeywordDTO(string keyword);
    //public List<StudentDTO> findByCourseId(int courseId);
}
