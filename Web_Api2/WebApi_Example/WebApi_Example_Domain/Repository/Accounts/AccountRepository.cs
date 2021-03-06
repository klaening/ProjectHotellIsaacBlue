﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
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

        public async Task<Accounts> GetAccount(string id)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                return await c.QueryFirstOrDefaultAsync<Accounts>("SELECT * FROM ACCOUNTS WHERE USERNAME = @id", new { id });
            }
        }

        public async Task<Accounts> GetAccount(string userName, string password)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                return await c.QueryFirstOrDefaultAsync<Accounts>("SELECT * FROM ACCOUNTS WHERE USERNAME = @userName AND USERPASSWORD = @password", new { userName, password });
            }
        }

        public async Task<bool> AddAccount(Accounts accounts)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    await c.ExecuteAsync("INSERT INTO ACCOUNTS (USERNAME, USERPASSWORD, CUSTOMERSID) VALUES (@username, @userpassword, @customersid)", new { accounts.USERNAME, accounts.USERPASSWORD, accounts.CUSTOMERSID });
                    return true;
                }
                catch (System.Exception)
                {
                    return false;
                }
            }
        }

        public async Task<bool> UpdateAccount(Accounts account)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    await c.ExecuteAsync("UPDATE ACCOUNTS SET USERNAME = @username, USERPASSWORD = @userpassword, CUSTOMERSID = @customersid WHERE ID = @id", new { account.USERNAME, account.USERPASSWORD, account.CUSTOMERSID, account.ID });
                    return true;
                }
                catch (System.Exception)
                {
                    return false;
                }
            }
        }

        public async Task<bool> DeleteAccount(int id)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    await c.ExecuteAsync("DELETE FROM ACCOUNTS WHERE ID = @id", new { id });
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
