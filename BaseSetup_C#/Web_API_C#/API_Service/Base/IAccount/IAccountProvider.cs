using Core.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.IAccount;
public interface IAccountProvider
{
    IEnumerable<Account> Account_GetAll(string connectionString);
    Account Account_GetByID(string connectionString, int id);
}
