using API.Dtos;
using API.Models;

namespace AccountBankAPI.Services;

public interface AccountService
{

    public AccountDTO Login(string username, string password);
    public string GenerateJSONWebToken(string username);
    public AccountDTO findByUsername(string username);
    public AccountDTO findById(int id);

    public bool CreateDTO(AccountDTO accountDTO);
    public bool UpdateDTO(AccountDTO accountDTO);
}
