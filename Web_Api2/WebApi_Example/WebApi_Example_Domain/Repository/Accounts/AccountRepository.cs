using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;

namespace WebApi_Example_Domain.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly string _connectionString;

        public AccountRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Accounts>> GetAccounts()
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    return await c.QueryAsync<Accounts>("SELECT * FROM ACCOUNTS");
                }
                catch (System.Exception ex)
                {
                    var p = ex;
                    throw;
                }
            }
        }

        public async Task<Accounts> GetAccount(int id)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                return await c.QueryFirstOrDefaultAsync<Accounts>("SELECT * FROM ACCOUNTS WHERE ID = @id", new { id });
            }
        }

        public async Task<bool> AddAccount(Accounts accounts)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    await c.ExecuteAsync("INSERT INTO ACCOUNTS (ID, USERNAME, USERPASSWORD, CUSTOMERSID) VALUES (@id, @username, @userpassword, @customersid)", new { accounts.ID, accounts.USERNAME, accounts.USERPASSWORD, accounts.CUSTOMERSID });
                    return true;
                }
                catch (System.Exception)
                {
                    return false;
                }

            }
        }
    }
}
