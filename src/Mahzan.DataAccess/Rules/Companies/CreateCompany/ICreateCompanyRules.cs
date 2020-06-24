using Mahzan.DataAccess.DTO.Companies.CreateCompany;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Rules.Companies.CreateCompany
{
    public interface ICreateCompanyRules
    {
        Task HandleRules(CreateCompanyDto createCompanyDto);
    }
}
