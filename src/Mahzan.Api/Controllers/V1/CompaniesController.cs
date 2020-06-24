using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Api.Commands.Companies.CreateCompany;
using Mahzan.Api.Controllers._Base;
using Mahzan.Api.Exceptions;
using Mahzan.Api.Filters.Companies;
using Mahzan.Business.Events.Companies.CreateCompany;
using Mahzan.Business.EventsHandlers.Companies.CreateCompany;
using Mahzan.DataAccess.DTO.Companies.GetCompanies;
using Mahzan.DataAccess.Repositories._BaseController;
using Mahzan.DataAccess.Repositories.Companies.GetCompanies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mahzan.Api.Controllers.V1
{
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CompaniesController : BaseController
    {
        private readonly ICreateCompanyEventHandler _createCompanyEventHandler;

        private readonly IGetCompaniesRepository _getCompaniesRepository;

        public CompaniesController(
            IBaseControllerRepository baseControllerRepository,
            ICreateCompanyEventHandler createCompanyEventHandler, 
            IGetCompaniesRepository getCompaniesRepository) : base(baseControllerRepository)
        {
            _createCompanyEventHandler = createCompanyEventHandler;
            _getCompaniesRepository = getCompaniesRepository;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateCompanyCommand command)
        {
            try
            {
                await _createCompanyEventHandler
                    .Handle(new CreateCompanyEvent
                    {
                        CompanyEvent = new CompanyEvent
                        {
                            RFC = command.Company.RFC,
                            ComercialName = command.Company.ComercialName,
                            BusinessName = command.Company.BusinessName,
                            GroupId = command.Company.GroupId
                        },
                        CompanyAdressEvent = new CompanyAdressEvent
                        {
                            Street = command.CompanyAdress.Street,
                            Number = command.CompanyAdress.Number,
                            InternalNumber = command.CompanyAdress.InternalNumber,
                            PostalCode = command.CompanyAdress.PostalCode,
                        },
                        CompanyContactEvent = new CompanyContactEvent
                        {
                            ContactName = command.CompanyContact.ContactName,
                            Email = command.CompanyContact.Email,
                            Phone = command.CompanyContact.Phone,
                            WebSite = command.CompanyContact.WebSite
                        },
                        MemberId = MemberId
                    });


            }
            catch (ArgumentException ex)
            {

                throw new ServiceArgumentException(ex);
            }

            return Ok();
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetCompaniesFilter filter)
        {
            List<Models.Entities.Companies> companies = await _getCompaniesRepository
                .HandleRepository(new GetCompaniesDto
                {
                    CompanyId = filter.CompanyId,
                    CommercialName = filter.CommercialName,
                    MemberId = MemberId
                });

            return Ok(companies);
        }
    }
}
