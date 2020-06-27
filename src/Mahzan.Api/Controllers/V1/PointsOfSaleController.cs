using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Api.Commands.PointsOfSale.CreatePointOfSale;
using Mahzan.Api.Controllers._Base;
using Mahzan.Api.Filters.PointsOfSale;
using Mahzan.Business.Events.PointsOfSale;
using Mahzan.Business.EventsHandlers.PointsOfSale.CreatePointOfSale;
using Mahzan.DataAccess.DTO.PointsOfSale.GetPointsOfSale;
using Mahzan.DataAccess.Repositories._BaseController;
using Mahzan.DataAccess.Repositories.PointsOfSale.GetPointsOfSale;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mahzan.Api.Controllers.V1
{
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PointsOfSaleController : BaseController
    {
        private readonly ICreatePointOfSaleEventHandler _createPointOfSaleEvent;

        private readonly IGetPointsOfSaleRepository _getPointsOfSaleRepository;

        public PointsOfSaleController(
            IBaseControllerRepository baseControllerRepository,
            ICreatePointOfSaleEventHandler createPointOfSaleEvent,
            IGetPointsOfSaleRepository getPointsOfSaleRepository) : base(baseControllerRepository)
        {
            _createPointOfSaleEvent = createPointOfSaleEvent;
            _getPointsOfSaleRepository = getPointsOfSaleRepository;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreatePointOfSaleCommand command)
        {

            try
            {
                await _createPointOfSaleEvent
                    .HandleEvent(new CreatePointOfSaleEvent
                    {
                        Code = command.Code,
                        Name = command.Name,
                        StoreId = command.StoreId,
                        MemberId = MemberId
                    });
            }
            catch (Exception)
            {

                throw;
            }

            return Ok();
        }


        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public async Task<IActionResult> Get([FromBody]GetPointsOfSaleFilter filter)
        {
            List<Models.Entities.Points_Of_Sale> pointOfSale;
            pointOfSale = await _getPointsOfSaleRepository
                .HandleRepository(new GetPointsOfSaleDto
                {
                    PointOfSaleId = filter.PointOfSaleId,
                    Code = filter.Code,
                    Name = filter.Name
                });

            return Ok(pointOfSale);
        }
    }
}
