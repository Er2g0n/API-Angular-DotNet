using Base.IAccount;
using Core.Models.Account;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using System.Data.Common;

namespace Data.AccountP;
public class AccountProvider : IAccountProvider
{
    public IEnumerable<Account> Account_GetAll(string connectionString)
    {
        try {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                dbConnection.Open();
                var accounts = dbConnection.Query<Account>(
                    "Account_GetALL",
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 240
                );
                return accounts;
            }
        }
        catch (Exception) { return null; }
        
    }

    public Account Account_GetByID(string connectionString, int id)
    {
        try
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@ID", id);
                var account = dbConnection.QuerySingleOrDefault<Account>(
                    "Account_GetByID",
                    parameters,
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 240
                );
                return account;
            }
        }
        catch (Exception) { return null; }
    }
}
