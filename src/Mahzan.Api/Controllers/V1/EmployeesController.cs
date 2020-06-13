using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Api.Commands.Employees;
using Mahzan.Api.Controllers._Base;
using Mahzan.Api.Exceptions;
using Mahzan.Api.Services;
using Mahzan.Business.Events.Employees;
using Mahzan.Business.EventsHandlers.Employees.Create;
using Mahzan.Business.Results.Employees;
using Mahzan.DataAccess.Repositories._BaseController;
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

        private readonly IEmailSender _emailSender;


        public EmployeesController(
            IBaseControllerRepository baseControllerRepository,
            ICreateEmployeeEventHandler createEmployeeEvent,
            IEmailSender emailSender) : base(baseControllerRepository)
        {
            _createEmployeeEvent = createEmployeeEvent;
            _emailSender = emailSender;
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


    }
}
