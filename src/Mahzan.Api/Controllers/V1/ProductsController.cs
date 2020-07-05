using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Mahzan.Api.Commands.Products.CreateProduct;
using Mahzan.Api.Controllers._Base;
using Mahzan.Business.Events.Products.CreateProduct;
using Mahzan.Business.EventsHandlers.Products.CreateProduct;
using Mahzan.DataAccess.Repositories._BaseController;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mahzan.Api.Controllers.V1
{
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        private readonly ICreateProductEventHandler _createProductEventHandler;

        private readonly IMapper _mapper;

        public ProductsController(
            IBaseControllerRepository baseControllerRepository,
            ICreateProductEventHandler createProductEventHandler) : base(baseControllerRepository)
        {
            _createProductEventHandler = createProductEventHandler;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
        {

            try
            {
                await _createProductEventHandler
                    .HandleEvent(_mapper.Map<CreateProductEvent>(command));
            }
            catch (Exception)
            {

                throw;
            }

            return Ok();
        }
    }
}
