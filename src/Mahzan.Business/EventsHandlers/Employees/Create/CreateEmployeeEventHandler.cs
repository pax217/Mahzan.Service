using Mahzan.Business.Events.Employees;
using Mahzan.Business.Results.Employees;
using Mahzan.DataAccess.DTO.Employees;
using Mahzan.DataAccess.Repositories.Employees.CreateEmployee;
using Mahzan.Models.Enums.Result;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Business.EventsHandlers.Employees.Create
{
    public class CreateEmployeeEventHandler : ICreateEmployeeEventHandler
    {
        private readonly ICreateEmployeeRepository _createEmployeeRepository;

        public CreateEmployeeEventHandler(
            ICreateEmployeeRepository createEmployeeRepository)
        {
            _createEmployeeRepository = createEmployeeRepository;
        }

        public async Task<Mahzan.Models.Entities.Users> HandleEvent(CreateEmployeeEvent createEmployeeEvent)
        {
            Mahzan.Models.Entities.Users user = await _createEmployeeRepository
                .HandleRepository(new CreateEmployeeDto
                {
                    CodeEmploye = createEmployeeEvent.CodeEmploye,
                    FirstName = createEmployeeEvent.FirstName,
                    SecondName = createEmployeeEvent.SecondName,
                    LastName = createEmployeeEvent.LastName,
                    SureName = createEmployeeEvent.SureName,
                    Email = createEmployeeEvent.Email,
                    Phone = createEmployeeEvent.Phone,
                    RoleId = createEmployeeEvent.RoleId,
                    UserName = createEmployeeEvent.UserName,
                    Password = createEmployeeEvent.Password,
                    MemberId = createEmployeeEvent.MemberId,
                    UserId = createEmployeeEvent.UserId
                });

            return user;
        }
    }
}
