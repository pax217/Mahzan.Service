using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Api.Commands.Employees;
using Mahzan.Api.Controllers._Base;
using Mahzan.Api.Exceptions;
using Mahzan.Api.Filters.Employees;
using Mahzan.Api.Paging;
using Mahzan.Api.Services;
using Mahzan.Api.ViewModels.Employees.GetEmployees;
using Mahzan.Business.Events.Employees;
using Mahzan.Business.EventsHandlers.Employees.Create;
using Mahzan.Business.Results.Employees;
using Mahzan.DataAccess.DTO.Employees;
using Mahzan.DataAccess.Repositories._BaseController;
using Mahzan.DataAccess.Repositories.Employees.GetEmployees;
using Mahzan.Models.Enums.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mahzan.Api.Controllers.V1
{
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController
    {

        private readonly ICreateEmployeeEventHandler _createEmployeeEvent;

        private readonly IGetEmployeesRepository _getEmployeesRepository;

        private readonly IEmailSender _emailSender;


        public EmployeesController(
            IBaseControllerRepository baseControllerRepository,
            ICreateEmployeeEventHandler createEmployeeEvent,
            IEmailSender emailSender, 
            IGetEmployeesRepository getEmployeesRepository) : base(baseControllerRepository)
        {
            _createEmployeeEvent = createEmployeeEvent;
            _emailSender = emailSender;
            _getEmployeesRepository = getEmployeesRepository;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateEmployeeCommand command) 
        {
            CreateEmployeeResult result = new CreateEmployeeResult
            {
                IsValid = true,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = "Crea un empleado",
                Message = $"El empleado se ha creado correctamente."
            };
            string userNamePattern = HttpContext.User.Claims.ToList()[0].Value;

            try
            {
                Models.Entities.Users user = await _createEmployeeEvent
                    .HandleEvent(new CreateEmployeeEvent
                    {
                        CodeEmploye = command.CodeEmploye,
                        FirstName = command.FirstName,
                        SecondName = command.SecondName,
                        LastName = command.LastName,
                        SureName = command.SureName,
                        Email = command.Email,
                        Phone = command.Phone,
                        RoleId = command.RoleId,
                        UserName = userNamePattern + "." + command.UserName,
                        Password = command.Password,
                        MemberId = MemberId,
                        UserId =UserId
                    });

                if (user!=null)
                {
                    await _emailSender
                        .SendEmailAsync(
                            user.Email,
                            "Confirma tu Email",
                            $"Por favor confirma tu email, haz click <a href='http://159.203.81.150:5000/v1/users/confirm-email?userId={user.UserId}&tokenConfrimEmail={user.TokenConfirmEmail}'>aquí</a>");

                }
            }
            catch (ArgumentException ex)
            {
                throw new ServiceArgumentException(ex);
            }

            return Ok(result);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateEmployeeCommand command) 
        {

            return Ok();
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(UpdateEmployeeCommand command)
        {

            return Ok();
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] GetEmployeesFilter filter)
        {
            GetEmployeesViewModel getEmployeesViewModel = new GetEmployeesViewModel(); 

            try
            {
                List<Models.EntitiesExtensions.EmployeesExtension> employees = await _getEmployeesRepository
                    .HandleRepository(new GetEmployeesDto
                    {
                        EmployeeId = filter.EmployeeId,
                        CodeEmployee = filter.CodeEmployee,
                        FirstName = filter.FirstName,
                        MemberId = MemberId,
                    });

                //PagedList
                getEmployeesViewModel.employees = PagedList<Models.EntitiesExtensions.EmployeesExtension>
                    .ToPagedList(
                        employees,
                        filter.PageNumber,
                        filter.PageSize);

                //Paging
                getEmployeesViewModel.paging = new Paging.Paging
                {
                    TotalCount = getEmployeesViewModel.employees.TotalCount,
                    PageSize = getEmployeesViewModel.employees.PageSize,
                    CurrentPage = getEmployeesViewModel.employees.CurrentPage,
                    TotalPages = getEmployeesViewModel.employees.TotalPages,
                    HasNext = getEmployeesViewModel.employees.HasNext,
                    HasPrevious = getEmployeesViewModel.employees.HasPrevious
                };
            }
            catch (Exception ex)
            {
                throw;
            }

            return Ok(getEmployeesViewModel);
        }

    }
}
