using Microsoft.AspNetCore.Mvc;
using StudentAPI_BE.Dtos;
using StudentAPI_BE.Services;

namespace StudentAPI_BE.Controllers;
[Route("api/course")]

public class CourseController(
    CourseService courseService,
    IConfiguration configuration,
    IWebHostEnvironment webHostEnvironment
    ) : Controller
{

    private CourseService courseService = courseService;
    private IConfiguration configuration = configuration;
    [Produces("application/json")]
    [HttpGet("findAllCourseByStudentId/{id}")]
    public IActionResult FindAllCourseByStudentId(int id)
    {
        try
        {
            return Ok(courseService.findAllCourseByStudentId(id));
        }
        catch
        {

            return BadRequest();
        }
    }
    [Produces("application/json")]
    [HttpGet("findCourseById/{id}")]
    public IActionResult FindStudentById(int id)
    {
        try
        {
            return Ok(courseService.findCourseById(id));
        }
        catch
        {

            return BadRequest();
        }
    }
    [Produces("application/json")]
    [HttpGet("findCourseByKeywordDTO/{keyword}")]
    public IActionResult FindCourseByKeywordDTO(string keyword)
    {
        try
        {
            return Ok(courseService.findCourseByKeywordDTO(keyword));
        }
        catch
        {

            return BadRequest();

        }
    }
    [Produces("application/json")]
    [HttpGet("findCourseByScoreDTO/{score}")]
    public IActionResult findCourseByScoreDTO(int score)
    {
        try
        {
            return Ok(courseService.findCourseByScoreDTO(score));
        }
        catch
        {

            return BadRequest();

        }
    }
    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPost("create")]
    public IActionResult Create([FromBody] CourseDTO courseDTO)
    {
        try
        {
            return Ok(courseService.create(courseDTO));
        }
        catch
        {
            return BadRequest();
        }
    }
    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPut("update")]
    public IActionResult Update([FromBody] CourseDTO courseDTO)
    {
        try
        {
            return Ok(courseService.update(courseDTO));
        }
        catch
        {
            return BadRequest();
        }
    }
    [Produces("application/json")]
    [HttpDelete("delete/{courseId}")]
    public IActionResult Delete(int courseId)
    {
        try
        {
            return Ok(new
            {
                Result = courseService.delete(courseId)
            });
        }

        catch
        {
            return BadRequest();
        }
    }
}
