using AutoMapper;
using StudentAPI_BE.Dtos;
using StudentAPI_BE.Models;
using System.Data.Common;
using System.Linq;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace StudentAPI_BE.Services;

public class CourseServiceImpl(IMapper mapper, DatabaseContext db) : CourseService
{
    private readonly IMapper mapper = mapper;
    private readonly DatabaseContext db = db;

    public bool create(CourseDTO courseDTO)
    {
        var course = mapper.Map<Course>(courseDTO);
        db.Courses.Add(course);
        return db.SaveChanges()>0;
    }

    public bool delete(int courseId)
    {
        db.Courses.Remove(db.Courses.Find(courseId));
        return db.SaveChanges()>0;
    }

    public List<CourseDTO> findAllCourse()
    {
        return mapper.Map<List<CourseDTO>>(db.Courses.ToList());
    }

    public List<CourseDTO> findAllCourseByStudentId(int id)
    {
        return mapper.Map<List<CourseDTO>>(db.Courses.Where(d => d.StudentId == id).ToList());
    }

    public CourseDTO findCourseById(int courseID)
    {
        return mapper.Map<CourseDTO>(db.Courses.Find(courseID));
    }

    public List<CourseDTO> findCourseByKeywordDTO(string keyword)
    {
        return mapper.Map<List<CourseDTO>>(db.Courses.Where(c => c.CourseName.Contains(keyword)).ToList());
    }

    public List<CourseDTO> findCourseByScoreDTO(int score)
    {
        return mapper.Map<List<CourseDTO>>(db.Courses.Where(c => c.CourseScore == score).ToList());
    }

    public bool update(CourseDTO courseDTO)
    {
        try
        {
            var course = mapper.Map<Course>(courseDTO);
            db.Entry(course).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
