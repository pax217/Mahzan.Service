using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Api.Commands.SalesDepartments.CreateSaleDepartment;
using Mahzan.Api.Commands.SalesDepartments.CreateSaleDepartmentFull;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mahzan.Api.Controllers.V1
{
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class SalesDepartmentsController : ControllerBase
    {

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateSaleDepartmentCommand command)
        {

            return Ok();
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("create-full")]
        public async Task<IActionResult> CreateFull(CreateSaleDepartmentFullCommand command)
        {

            return Ok();
        }
    }
}
