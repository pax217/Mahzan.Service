using Dapper;
using Mahzan.DataAccess.DTO.Companies.GetCompanies;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Repositories.Companies.GetCompanies
{
    public class GetCompaniesRepository : DataConnection, IGetCompaniesRepository
    {
        public GetCompaniesRepository(
            IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<List<Models.Entities.Companies>> HandleRepository(GetCompaniesDto getCompaniesDto)
        {
            DynamicParameters parameters = new DynamicParameters();

            StringBuilder sql = new StringBuilder();
            sql.Append("select * from companies ");
            sql.Append("where 1=1 ");

            if (getCompaniesDto.MemberId!=null)
            {
                sql.Append("and member_id=@member_id ");
                parameters.Add("@member_id", getCompaniesDto.MemberId, DbType.Guid);
            }

            if (getCompaniesDto.CompanyId != null)
            {
                sql.Append("and company_id = @company_id ");
                parameters.Add("@company_id", getCompaniesDto.CompanyId, DbType.Guid);
            }

            if (getCompaniesDto.CommercialName != null)
            {
                sql.Append("and commercial_name LIKE @commercial_name ");
                parameters.Add("@commercial_name", "%" + getCompaniesDto.CommercialName + "%", DbType.String);
            }

            IEnumerable<Models.Entities.Companies> companies;
            companies = await Connection
                .QueryAsync<Models.Entities.Companies>(
                    sql.ToString(),
                    parameters
                );

            return companies.ToList();
        }
    }
}
