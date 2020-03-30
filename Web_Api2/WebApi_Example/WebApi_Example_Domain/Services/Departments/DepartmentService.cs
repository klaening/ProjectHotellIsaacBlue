using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;
using WebApi_Example_Domain.Repository;

namespace WebApi_Example_Domain.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<IEnumerable<Departments>> GetDepartments()
        {
            return await _departmentRepository.GetDepartments();
        }

        public async Task<Departments> GetDepartment(int id)
        {
            return await _departmentRepository.GetDepartment(id);
        }
    }
}
