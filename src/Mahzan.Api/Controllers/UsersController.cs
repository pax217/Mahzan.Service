using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Api.Commands.Users;
using Mahzan.Api.Exceptions;
using Mahzan.Api.Services;
using Mahzan.Business.Events.Users;
using Mahzan.Business.EventsHandlers.Users.Login;
using Mahzan.Business.EventsHandlers.Users.SignUp;
using Mahzan.Business.Results.Users;
using Mahzan.DataAccess.Repositories.Users.ConfirmEmail;
using Mahzan.Models._Base;
using Mahzan.Models.Enums.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mahzan.Api.Controllers
{
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILoginEventHandler _loginEventHandler;

        private readonly ISignUpEventHandler _signUpEventHandler;

        private readonly IEmailSender _emailSender;

        private readonly IConfirmEmailRepository _confirmEmailRepository;

        public UsersController(
            ILoginEventHandler loginEventHandler,
            ISignUpEventHandler signUpEventHandler,
            IEmailSender emailSender, 
            IConfirmEmailRepository confirmEmailRepository)
        {
            _loginEventHandler = loginEventHandler;
            _signUpEventHandler = signUpEventHandler;
            _emailSender = emailSender;
            _confirmEmailRepository = confirmEmailRepository;
        }

        [AllowAnonymous]
        [HttpGet("sign-in")]
        public async Task<IActionResult> SignIn(string userName, string passowrd)
        {
            LoginResult result;

            try
            {
                result = await _loginEventHandler
                    .HandleEvent(new LoginEvent
                    {
                        UserName = userName,
                        Password = passowrd
                    });

                //Obtiene Token
            }
            catch (ArgumentException ex)
            {
                throw new ServiceArgumentException(ex);
            }
            catch (InvalidOperationException ex)
            {
                throw new ServiceInvalidOperationException(ex);
            }

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp([FromBody] SignUpCommand command)
        {
            SignUpResult result = new SignUpResult
            {
                IsValid = true,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = "Registro de Usuario",
                Message = $"El usuario {command.UserName} ha sido registrado correctamente."
            };

            try
            {
                Models.Entities.Users user = await _signUpEventHandler
                    .HandleEvent(new SignUpEvent
                    {
                        Name = command.Name,
                        Phone = command.Phone,
                        Email = command.Email,
                        UserName = command.UserName,
                        Password = command.Password
                    });

                //Envia correo 
                if (user != null)
                {
                    await _emailSender
                        .SendEmailAsync(
                            "pax_217@hotmail.com",
                            "Confirma tu Email",
                            $"Por favor confirma tu email, haz click <a href='http://159.203.81.150:5000/v1/users/confirm-email?userId={user.UserId}&tokenConfrimEmail={user.TokenConfirmEmail}'>aquí</a>");
                }
            }
            catch (ServiceInvalidOperationException ex)
            {

                throw new ServiceInvalidOperationException(ex);
            }
            catch (ServiceArgumentException ex)
            {

                throw new ServiceArgumentException(ex);
            }

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string userId, string tokenConfrimEmail)
        {
            try
            {
                await _confirmEmailRepository
                    .HandleRepository(new Guid(userId), new Guid(tokenConfrimEmail));
            }
            catch (ServiceInvalidOperationException ex)
            {

                throw new ServiceInvalidOperationException(ex);
            }

            return Content("Se ha confirmado correctamente tu Email.");
        }
    }
}

