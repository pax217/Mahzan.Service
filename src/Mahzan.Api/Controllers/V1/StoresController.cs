using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Api.Commands.Companies.CreateCompany;
using Mahzan.Api.Commands.Stores;
using Mahzan.Api.Controllers._Base;
using Mahzan.Api.Filters.Stores.GetStores;
using Mahzan.Business.Events.Stores;
using Mahzan.Business.EventsHandlers.Stores.CreateStore;
using Mahzan.DataAccess.DTO.Stores.GetStores;
using Mahzan.DataAccess.Repositories._BaseController;
using Mahzan.DataAccess.Repositories.Stores.GetStores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mahzan.Api.Controllers.V1
{
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class StoresController : BaseController
    {
        private readonly ICreateStoreEventHandler _createStoreEventHandler;

        private readonly IGetStoresRepository _getStoresRepository;

        public StoresController(
            IBaseControllerRepository baseControllerRepository,
            ICreateStoreEventHandler createStoreEventHandler, 
            IGetStoresRepository getStoresRepository) : base(baseControllerRepository)
        {
            _createStoreEventHandler = createStoreEventHandler;
            _getStoresRepository = getStoresRepository;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateStoreCommand command)
        {

            try
            {
                await _createStoreEventHandler
                    .HandleEvent(new CreateStoreEvent
                    {
                        Code = command.Code,
                        Name = command.Name,
                        Phone = command.Phone,
                        Comment = command.Comment,
                        CompanyId = command.CompanyId,
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
        [HttpGet()]
        public async Task<IActionResult> Get(GetStoresFilter filter)
        {

            try
            {
                List<Models.Entities.Stores> stores = await _getStoresRepository
                    .HandleRepository(new GetStoresDto()
                    {
                        StoreId = filter.StoreId,
                        Name = filter.Name,
                        MemberId = MemberId
                    });


            }
            catch (Exception)
            {

                throw;
            }

            return Ok();
        }
    }
}
