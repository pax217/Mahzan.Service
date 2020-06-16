using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.DataAccess.Repositories.Roles.GetRoles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mahzan.Api.Controllers.V1
{
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IGetRolesRepository _getRolesRepository;

        public RolesController(
            IGetRolesRepository getRolesRepository)
        {
            _getRolesRepository = getRolesRepository;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet()]
        public async Task<IActionResult> Get()
        {

            List<Models.Entities.Roles> roles = await _getRolesRepository
                .HandleRepository();

            return Ok(roles);

        }
    }
}
