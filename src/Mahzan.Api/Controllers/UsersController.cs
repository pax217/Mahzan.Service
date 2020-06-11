using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Api.Commands.Users;
using Mahzan.Api.Exceptions;
using Mahzan.Business.Events.Users;
using Mahzan.Business.EventsHandlers.Users.Login;
using Mahzan.Business.Results.Users;
using Mahzan.Models._Base;
using Mahzan.Models.Enums.Result;
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

        public UsersController(
            ILoginEventHandler loginEventHandler)
        {
            _loginEventHandler = loginEventHandler;
        }

        [HttpGet("login")]
        public async Task<IActionResult> Login(string userName, string passowrd) 
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

            return Ok(result);
        }

    }
}
