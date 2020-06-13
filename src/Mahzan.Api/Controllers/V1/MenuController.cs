using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Api.Controllers._Base;
using Mahzan.Business.Events.Menu.GetAside;
using Mahzan.Business.EventsHandlers.Menu.GetAside;
using Mahzan.Business.Models.Menu.GetAside;
using Mahzan.DataAccess.Repositories._BaseController;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mahzan.Api.Controllers.V1
{
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class MenuController : BaseController
    {

        private readonly IGetAsideEventHandler _getAsideEventHandler;

        public MenuController(
            IBaseControllerRepository baseControllerRepository,
            IGetAsideEventHandler getAsideEventHandler)
            :base(baseControllerRepository)
        {
            _getAsideEventHandler = getAsideEventHandler;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("get-aside")]
        public async Task<IActionResult> GetAside()
        {
            MenuModel result;

            try
            {
                result = await _getAsideEventHandler
                    .HandleEvent(new GetAsideEvent
                    {
                        RoleId = RoleId
                    });

            }
            catch (Exception ex)
            {

                throw;
            }

            return Ok(result);
        }

    }
}
