using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Mahzan.Api.Commands.SalesDepartments.CreateSaleDepartment;
using Mahzan.Api.Commands.SalesDepartments.CreateSaleDepartmentFull;
using Mahzan.Api.Controllers._Base;
using Mahzan.Api.Exceptions;
using Mahzan.DataAccess.DTO.SalesDepartments.CreateSalesDepartmentsFull;
using Mahzan.DataAccess.Repositories._BaseController;
using Mahzan.DataAccess.Repositories.SalesDepartments.CreateSalesDepartmentsFull;
using Mahzan.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mahzan.Api.Controllers.V1
{
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class SalesDepartmentsController : BaseController
    {
        private readonly ICreateSalesDepartmentsFullRepository _createSalesDepartmentsFullRepository;

        private readonly IMapper _mapper;

        public SalesDepartmentsController(
            IBaseControllerRepository baseControllerRepository,
            ICreateSalesDepartmentsFullRepository createSalesDepartmentsFullRepository, 
            IMapper mapper) : base(baseControllerRepository)
        {
            _createSalesDepartmentsFullRepository = createSalesDepartmentsFullRepository;
            _mapper = mapper;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateSaleDepartmentCommand command)
        {

            return Ok();
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("create-full")]
        public async Task<IActionResult> CreateFull(CreateSalesDepartmentsFullCommand command)
        {
            try
            {
                await _createSalesDepartmentsFullRepository
                    .HandleRepository(
                        _mapper.Map<CreateSalesDepartmentsFullDto>(command),
                        MemberId
                    );
            }
            catch (ArgumentException ex)
            {
                throw new ServiceArgumentException(ex);
            }

            return Ok();
        }
    }
}
