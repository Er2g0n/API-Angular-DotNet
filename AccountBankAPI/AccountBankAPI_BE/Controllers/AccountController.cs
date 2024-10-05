using AccountBankAPI.Services;
using API.Dtos;
using API.Models;
using BCrypt.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace API.Controllers;
[Route("api/account")]
[ApiController]
public class AccountController : Controller
{
    private AccountService accountService;
    private IConfiguration configuration;
    private IWebHostEnvironment webHostEnvironment;


    public AccountController(AccountService _accountService,IConfiguration _configuration,IWebHostEnvironment _webHostEnvironment)
    {
        configuration = _configuration;
        accountService = _accountService;
        webHostEnvironment = _webHostEnvironment;

    }

   
    [Consumes("application/json")]
    [Produces("application/json")]
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDTO loginDTO)
    {
        try
        {
            // Validate the user credentials
          
            var acountLogin = accountService.Login(loginDTO.username, loginDTO.password);

            return Ok(acountLogin);
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }


    [Consumes("application/json")]
    [Produces("application/json")]
    [HttpPost("register")]
    public IActionResult Register([FromBody] AccountDTO accountDTO)
    {
        try
        {
            if (accountDTO == null)
            {
                return BadRequest(new { error = "invalid account data" });
            }

            accountDTO.Password= BCrypt.Net.BCrypt.HashPassword(accountDTO.Password);
            // đặt số dư ban đầu là 0
            accountDTO.Balance = 0;

            // gọi service để đăng ký tài khoản mới
            if (accountService.CreateDTO(accountDTO))
            {
                return Ok(new { message = "account registered successfully" });
            }
            return BadRequest(new { error = "registration failed" });
        }
        catch
        {
            return BadRequest(new { error = "error during registration" });
        }

    }
    [Produces("application/json")]
    [HttpGet("findByUsername/{username}")]
    public IActionResult FindByUsername(string username)
    {
        try
        {
            return Ok(accountService.findByUsername(username));
        }
        catch
        {

            return BadRequest();
        }
    }
    [Produces("application/json")]
    [HttpGet("findById/{id}")]
    public IActionResult FindById(int id)
    {
        try
        {
            return Ok(accountService.findById(id));
        }
        catch
        {

            return BadRequest();
        }
    }
    [Consumes("application/json")]
    [Produces("application/json")]
    [HttpPut("updateDTO")]
    public IActionResult UpdateDTO([FromBody] AccountDTO accountDTO)
    {
        try
        {
            //accountDTO.Password = BCrypt.Net.BCrypt.HashPassword(accountDTO.Password);
            return Ok(new
            {
                Result = accountService.UpdateDTO(accountDTO)

            });
        }
        catch
        {

            return BadRequest();

        }
    }
}