﻿using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Example_Domain.Models;

namespace WebApi_Example_Domain.Services
{
    public interface IStaffService
    {
        Task<bool> AddStaff(Staff staff);
        Task<IEnumerable<Staff>> GetStaff();
        Task<Staff> GetStaff(int id);
    }
}
