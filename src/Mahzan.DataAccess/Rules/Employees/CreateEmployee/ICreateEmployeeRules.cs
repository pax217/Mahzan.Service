using Mahzan.DataAccess.DTO.Employees;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Rules.Employees.CreateEmployee
{
    public interface ICreateEmployeeRules
    {
        Task HandleRules(CreateEmployeeDto createEmployeeDto);
    }
}
