using Base.IAccount;
using Core.Models.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_System.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IConfiguration _config;
    private readonly IAccountProvider _accountProvider;
    private string connectionString;

    public AccountController(IConfiguration config, IAccountProvider accountProvider)
    {
        _config = config;
        _accountProvider = accountProvider;
        connectionString = config.GetConnectionString("DB");
    }

    [HttpGet("GetAll")]
    public IEnumerable<Account> GetAll()
    {
        return _accountProvider.Account_GetAll(connectionString);
    }
    [HttpGet("GetByID/{id}")]

    public Account GetByID(int id)
    {
        return _accountProvider.Account_GetByID(connectionString, id);
    }
}
