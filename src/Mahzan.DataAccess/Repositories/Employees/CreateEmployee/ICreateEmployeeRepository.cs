using Mahzan.DataAccess.DTO.Employees;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Repositories.Employees.CreateEmployee
{
    public interface ICreateEmployeeRepository
    {
        Task<Models.Entities.Users> HandleRepository(CreateEmployeeDto createEmployeeDto);
    }
}
