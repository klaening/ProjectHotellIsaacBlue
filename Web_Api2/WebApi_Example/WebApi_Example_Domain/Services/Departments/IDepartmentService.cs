using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;

namespace WebApi_Example_Domain.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Departments>> GetDepartments();
        Task<Departments> GetDepartment(int id);
    }
}
