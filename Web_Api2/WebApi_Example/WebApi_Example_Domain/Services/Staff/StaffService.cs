using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;
using WebApi_Example_Domain.Repository;

namespace WebApi_Example_Domain.Services
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _staffRepository;

        public StaffService(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        public async Task<IEnumerable<Staff>> GetStaff()
        {
            return await _staffRepository.GetStaff();
        }

        public async Task<Staff> GetStaff(int id)
        {
            return await _staffRepository.GetStaff(id);
        }

        public async Task<bool> AddStaff(Staff staff)
        {
            return await _staffRepository.AddStaff(staff);
        }
    }
}
