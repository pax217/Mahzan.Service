using Mahzan.DataAccess.DTO.Employees;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Repositories.Employees.GetEmployees
{
    public interface IGetEmployeesRepository
    {
        Task<List<Models.EntitiesExtensions.EmployeesExtension>> HandleRepository(GetEmployeesDto getEmployeesDto);
    }
}
