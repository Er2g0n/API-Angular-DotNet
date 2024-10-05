using API.Dtos;
using API.Models;
using AutoMapper;
using BCrypt.Net;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AccountBankAPI.Services;

public class AccountServiceImpl : AccountService
{
    private DatabaseContext db;
    private IMapper mapper;
    private IConfiguration configuration;
    public AccountServiceImpl (DatabaseContext _db, IMapper _mapper, IConfiguration _configuration)
    {
        db = _db;
        mapper = _mapper;
        configuration = _configuration;

    }


    public Account findByAccId(int? id)
    {
        return db.Accounts.SingleOrDefault(a => a.AccId == id);
        //return db.Accounts.Find(id);
    }


    public Account findByUsername(string username)
    {
        //return db.Accounts.SingleOrDefault(nv => nv.Username == username);
        return db.Accounts.FirstOrDefault(nv => nv.Username == username);

    }


    public string GenerateJSONWebToken(string username)
    {
        var issuer = configuration["Jwt:Issuer"];
        var audience = configuration["Jwt:Audience"];
        var key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(JwtRegisteredClaimNames.Name, username),

            }),
            Issuer = issuer,
            Audience = audience,
            Expires = DateTime.UtcNow.AddMinutes(10),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512)
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    } 

    public bool CreateDTO(AccountDTO accountDTO)
    {
        try
        {
            var account= mapper.Map<Account>(accountDTO);
            db.Accounts.Add(account);
            return db.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }
    public bool UpdateDTO(AccountDTO accountDTO)
    {
        try
        {
           var account  = db.Accounts.Find(accountDTO.AccId);
            if (account == null)
            {
                return false ;
            }
            if (!string.IsNullOrEmpty(accountDTO.FullName))
            {
                account.FullName = accountDTO.FullName;
            }
            if (!string.IsNullOrEmpty(accountDTO.Password))
            {
                account.Password = BCrypt.Net.BCrypt.HashPassword(accountDTO.Password);
            
            }
            if (!string.IsNullOrEmpty(accountDTO.Phone))
            {
                account.Phone = accountDTO.Phone;
            }
            if (!string.IsNullOrEmpty(accountDTO.Email))
            {
                account.Email = accountDTO.Email;
            }
            db.Accounts.Update(account);
            return db.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }

    AccountDTO AccountService.findByUsername(string username)
    {
        var account = db.Accounts.FirstOrDefault(a => a.Username == username);
        return mapper.Map<AccountDTO>(account);
    }

    public AccountDTO findById(int id)
    {
        return mapper.Map<AccountDTO>(db.Accounts.Find(id));
    }

    public AccountDTO Login(string username, string password)
    {
        var account = db.Accounts.FirstOrDefault(a => a.Username == username);

        return mapper.Map<AccountDTO>(account);
    }



}
