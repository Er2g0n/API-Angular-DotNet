using AutoMapper;
using StudentAPI_BE.Dtos;
using StudentAPI_BE.Models;

namespace StudentAPI_BE.Services;

public class StudentServiceImpl(IMapper mapper, DatabaseContext db) : StudentService
{
    private readonly IMapper mapper = mapper;
    private readonly DatabaseContext db = db;

    public bool Create(StudentDTO studentDTO)
    {
        try
        {
           var student = mapper.Map<Student>(studentDTO);
            db.Students.Add(student);
            return db.SaveChanges()>0;

        }
        catch (Exception ex)  
        {
            return false;
        }
    }

    public bool Delete(int studentId)
    {
        try
        {
            db.Students.Remove(db.Students.Find(studentId));
            return db.SaveChanges() > 0;

        }
        catch
        {
            return false;
        }
    }

    public List<StudentDTO> findAllStudents()
    {
        return mapper.Map<List<StudentDTO>>(db.Students.ToList());
    }


    
    public StudentDTO findStudentById(int studentId)
    {
        return mapper.Map<StudentDTO>(db.Students.Find(studentId));
    }

    public List<StudentDTO> findStudentByKeywordDTO(string keyword)
    {
        return mapper.Map<List<StudentDTO>>(db.Students.Where(c => c.Name.Contains(keyword)).ToList());

    }

    public bool Update(StudentDTO studentDTO)
    {
        try
        {
            var student = mapper.Map<Student>(studentDTO);
            db.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
