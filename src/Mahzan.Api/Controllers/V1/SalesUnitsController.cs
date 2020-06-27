using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Api.Commands.SalesUnits.CreateSaleUnit;
using Mahzan.Api.Controllers._Base;
using Mahzan.Api.Exceptions;
using Mahzan.DataAccess.DTO.SalesUnits.CreateSaleUnit;
using Mahzan.DataAccess.Repositories._BaseController;
using Mahzan.DataAccess.Repositories.SalesUnits.CreateSaleUnit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mahzan.Api.Controllers.V1
{
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class SalesUnitsController : BaseController
    {
        private readonly ICreateSaleUnitRepository _createSaleUnitRepository;

        public SalesUnitsController(
            IBaseControllerRepository baseControllerRepository, 
            ICreateSaleUnitRepository createSaleUnitRepository) : base(baseControllerRepository)
        {
            _createSaleUnitRepository = createSaleUnitRepository;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateSaleUnitCommand command)
        {
            try
            {
                await _createSaleUnitRepository
                    .HandleRepository(new CreateSaleUnitDto
                    {
                        Abreviation = command.Abreviation,
                        Description = command.Description,
                        StoreId = command.StoreId,
                        MemberId = MemberId
                    });
            }
            catch (ArgumentException ex)
            {

                throw new ServiceArgumentException(ex);
            }

            return Ok();
        }
    }
}
