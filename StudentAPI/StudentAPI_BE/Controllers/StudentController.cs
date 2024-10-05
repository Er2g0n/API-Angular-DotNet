using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using StudentAPI_BE.Dtos;
using StudentAPI_BE.Services;

namespace StudentAPI_BE.Controllers;
[Route("api/student")]

public class StudentController(
    StudentService studentService,
    IConfiguration configuration,
    IWebHostEnvironment webHostEnvironment
    ) : Controller
{
    private StudentService studenntService = studentService;
    private IConfiguration configuration = configuration;

    [Produces("application/json")]
    [HttpGet("findAllStudents")]
    public IActionResult FindAllStudents()
    {
        try
        {
            return Ok(studenntService.findAllStudents());
        }
        catch
        {

            return BadRequest();
        }
    }
    [Produces("application/json")]
    [HttpGet("findStudentById/{id}")]
    public IActionResult FindStudentById(int id)
    {
        try
        {
            return Ok(studenntService.findStudentById(id));
        }
        catch
        {

            return BadRequest();
        }
    }
    [Produces("application/json")]
    [HttpGet("findStudentByKeywordDTO/{keyword}")]
    public IActionResult FindStudentByKeywordDTO(string keyword)
    {
        try
        {
            return Ok(studenntService.findStudentByKeywordDTO(keyword));
        }
        catch
        {

            return BadRequest();

        }
    }
    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPost("create")]
    public IActionResult Create([FromBody] StudentDTO studentDTO)
    {
        try
        {
            return Ok(studentService.Create(studentDTO));
        }
        catch
        {
            return BadRequest();
        }
    }

    [Produces("application/json")]
    [Consumes("application/json")]
    [HttpPut("update")]
    public IActionResult Update([FromBody] StudentDTO studentDTO)
    {
        try
        {
            return Ok(studentService.Update(studentDTO));
        }
        catch
        {
            return BadRequest();
        }
    }
    [Produces("application/json")]
    [HttpDelete("delete/{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            return Ok(new
            {
                Result = studenntService.Delete(id)
            });
        }
        
        catch
        {
            return BadRequest();
        }
    }
}
