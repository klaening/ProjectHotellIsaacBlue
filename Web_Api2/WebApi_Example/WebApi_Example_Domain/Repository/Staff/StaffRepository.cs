using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;

namespace WebApi_Example_Domain.Repository
{
    public class StaffRepository : IStaffRepository
    {
        private readonly string _connectionString;

        public StaffRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Staff>> GetStaff()
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    return await c.QueryAsync<Staff>("SELECT * FROM STAFF");
                }
                catch (System.Exception ex)
                {
                    var p = ex;
                    throw;
                }
            }
        }

        public async Task<Staff> GetStaff(int id)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                return await c.QueryFirstOrDefaultAsync<Staff>("SELECT * FROM STAFF WHERE ID = @id", new { id });
            }
        }

        public async Task<bool> AddStaff(Staff staff)
        {
            using (var c = new SqlConnection(_connectionString))
            {
                try
                {
                    await c.ExecuteAsync("INSERT INTO STAFF (FIRSTNAME, LASTNAME, PHONENUMBER, EMAIL, DEPARTMENTSID) VALUES (@FirstName, @LastName, @PhoneNumber, @Email, @DepartmentsID)", new { staff.FIRSTNAME, staff.LASTNAME, staff.PHONENUMBER, staff.EMAIL, staff.DEPARTMENTSID });
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
