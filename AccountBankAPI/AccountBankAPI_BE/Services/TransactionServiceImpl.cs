using API.Dtos;
using API.Models;
using AutoMapper;
using DemoSession2_C2212L.Helpers;
using System.Diagnostics;

namespace AccountBankAPI.Services;

public class TransactionServiceImpl : TransactionService
{
    private DatabaseContext db;
    private AccountService accountService;
    private IMapper mapper;
    private IConfiguration configuration;

    public TransactionServiceImpl(DatabaseContext _db, AccountService _accountService,IMapper _mapper, IConfiguration _configuration)
    {
        db = _db;
        mapper = _mapper;
        configuration = _configuration;
        accountService = _accountService;
    }

    public bool TransactionDTO(TransactionDetailDTO transactionDetailDTO)
    {
        try

        {
            var account = db.Accounts.Find(transactionDetailDTO.AccId);
            
            account.Balance += (transactionDetailDTO.TransType == 0) ? transactionDetailDTO.TransMoney : transactionDetailDTO.TransMoney * -1;

            var transaction = mapper.Map<TransactionDetail>(transactionDetailDTO);

            db.Accounts.Update(account);

            db.TransactionDetails.Add(transaction);
            if (db.SaveChanges() > 0)
            {
                var mailHelper = new MailHelper(configuration);
                string transType = transactionDetailDTO.TransType == 2 ? "Withdraw" : "Deposit";
                string subject = $"Transaction Notification: {transType}";
                string body = $"Your account has just completed a {transType} transaction with the amount of {transactionDetailDTO.TransMoney}.";
                bool emailSent = mailHelper.Send(configuration["Gmail:Username"], account.Email, subject, body);

                if (!emailSent)
                {
                    // Handle email sending failure if necessary
                    throw new Exception("Failed to send email notification.");
                }
            }
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }


    public List<TransactionDetailDTO> GetAllTransactionByAccId(int id)
    {
        return mapper.Map<List<TransactionDetailDTO>>(db.TransactionDetails.Where(d => d.AccId == id).ToList());
    }

    public List<TransactionDetailDTO> FilterByTransactionType(int accountID, int TransType)
    {
        return mapper.Map<List<TransactionDetailDTO>>(db.TransactionDetails.Where(t => (t.TransType== TransType || TransType == -1) && t.AccId == accountID ).ToList());

    }
}
