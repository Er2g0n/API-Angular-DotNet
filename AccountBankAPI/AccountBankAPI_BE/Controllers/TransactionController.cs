using AccountBankAPI.Services;
using API.Models;
using System.Diagnostics;

using DemoSession2_C2212L.Helpers;
using Microsoft.AspNetCore.Mvc;
using API.Dtos;

namespace API.Controllers;
[Route("api/transaction")]

public class TransactionController : Controller
{
    private IConfiguration configuration;
    private AccountService accountService;
    private TransactionService transactionService;
    public TransactionController(IConfiguration _configuration, AccountService _accountService, TransactionService _transactionService)
    {
        configuration = _configuration;
        accountService = _accountService;
        transactionService = _transactionService;
    }
    [Produces("application/json")]
    [HttpGet("getAllTransactionAccById/{id}")]
    public IActionResult GetAllTransactionByAccId(int id)
    {

        try
        {
            return Ok(transactionService.GetAllTransactionByAccId(id));
        }
        catch
        {

            return BadRequest();

        }
    }

    [HttpPost("transactionDTO")]
    public IActionResult TransactionDTO([FromBody] TransactionDetailDTO transactionDetailDTO)
    {
        try
        {
            return Ok(new
            {
                Result = transactionService.TransactionDTO(transactionDetailDTO)

            });
        }
        catch
        {

            return BadRequest();

        }
    }
    [Produces("application/json")]
    [HttpGet("filterByTransactionType/{accountID}/{TransType}")]
    public IActionResult FilterByTransactionType(int accountID, int TransType)
    {
        try
        {
          

            return Ok(transactionService.FilterByTransactionType(accountID, TransType));
            
        }
        catch
        {
            return BadRequest();
        }
    }



}
