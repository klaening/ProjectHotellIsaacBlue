using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;

namespace WebApi_Example_Domain.Repository
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Departments>> GetDepartments();
        Task<Departments> GetDepartment(int id);
    }
}
