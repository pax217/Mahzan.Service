using Mahzan.DataAccess.DTO.Companies.CreateCompany;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Repositories.Companies.CreateCompany
{
    public interface ICreateCompanyRepository
    {
        Task Handle(CreateCompanyDto createCompanyDto);
    }
}
