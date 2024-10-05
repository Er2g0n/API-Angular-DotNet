
namespace API.Dtos;
public class TransactionDetailDTO
{
    public int TransId { get; set; }

    public int AccId { get; set; }

    public decimal TransMoney { get; set; }

    public int TransType { get; set; }

    public string DateOfTrans { get; set; }

}
