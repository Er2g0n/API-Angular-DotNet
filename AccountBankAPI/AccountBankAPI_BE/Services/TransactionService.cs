using API.Dtos;
using API.Models;
using System.Transactions;

namespace AccountBankAPI.Services;

public interface TransactionService
{
    //public TransactionDetail GetTransactionByTransId(int id);
    //public List<TransactionDetail> GetTransactionByAccId(int id);
    //public bool Withdraw(TransactionDetail transaction);

    public List<TransactionDetailDTO> FilterByTransactionType(int accountID, int TransType);
    public List<TransactionDetailDTO> GetAllTransactionByAccId(int id);

    public bool TransactionDTO(TransactionDetailDTO transactionDetailDTO);

}
