using Mahzan.Business.Events.Companies.CreateCompany;
using Mahzan.DataAccess.DTO.Companies.CreateCompany;
using Mahzan.DataAccess.Repositories.Companies.CreateCompany;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Business.EventsHandlers.Companies.CreateCompany
{
    public class CreateCompanyEventHandler : ICreateCompanyEventHandler
    {
        private readonly ICreateCompanyRepository _createCompanyRepository;

        public CreateCompanyEventHandler(
            ICreateCompanyRepository createCompanyRepository)
        {
            _createCompanyRepository = createCompanyRepository;
        }

        public async Task Handle(CreateCompanyEvent createCompanyEvent)
        {

            await _createCompanyRepository
                .Handle(
                    new CreateCompanyDto { 
                        CompanyDto  = new CompanyDto {
                            RFC = createCompanyEvent.CompanyEvent.RFC,
                            ComercialName = createCompanyEvent.CompanyEvent.ComercialName,
                            BusinessName = createCompanyEvent.CompanyEvent.BusinessName,
                            GroupId = createCompanyEvent.CompanyEvent.GroupId
                        },
                        CompanyAdressDto = new CompanyAdressDto {
                            Street = createCompanyEvent.CompanyAdressEvent.Street,
                            Number = createCompanyEvent.CompanyAdressEvent.Number,
                            InternalNumber = createCompanyEvent.CompanyAdressEvent.InternalNumber,
                            PostalCode = createCompanyEvent.CompanyAdressEvent.PostalCode,
                        },
                        CompanyContactDto = new CompanyContactDto {
                            ContactName = createCompanyEvent.CompanyContactEvent.ContactName,
                            Email = createCompanyEvent.CompanyContactEvent.Email,
                            Phone = createCompanyEvent.CompanyContactEvent.Phone,
                            WebSite = createCompanyEvent.CompanyContactEvent.WebSite
                        },
                        MemberId = createCompanyEvent.MemberId
                    }
                );

        }
    }
}
