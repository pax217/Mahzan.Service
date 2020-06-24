using Mahzan.DataAccess.DTO.Companies.GetCompanies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Repositories.Companies.GetCompanies
{
    public interface IGetCompaniesRepository
    {
        Task<List<Models.Entities.Companies>> HandleRepository(GetCompaniesDto getCompaniesDto);
    }
}
