using Mahzan.Business.Events.Employees;
using Mahzan.Business.Results.Employees;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Business.EventsHandlers.Employees.Create
{
    public interface ICreateEmployeeEventHandler
    {
        Task<Mahzan.Models.Entities.Users> HandleEvent(CreateEmployeeEvent createEmployeeEvent);
    }
}
