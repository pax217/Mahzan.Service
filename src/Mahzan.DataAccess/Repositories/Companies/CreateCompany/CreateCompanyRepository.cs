using Dapper;
using Mahzan.DataAccess.DTO.Companies.CreateCompany;
using Mahzan.DataAccess.Rules.Companies.CreateCompany;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Repositories.Companies.CreateCompany
{
    public class CreateCompanyRepository : DataConnection,ICreateCompanyRepository
    {
        private readonly ICreateCompanyRules _createCompanyRules;

        public CreateCompanyRepository(
            IDbConnection dbConnection, 
            ICreateCompanyRules createCompanyRules) : base(dbConnection)
        {
            _createCompanyRules = createCompanyRules;
        }

        public async Task Handle(CreateCompanyDto createCompanyDto)
        {
            //Rules
            await _createCompanyRules
                .HandleRules(createCompanyDto);

            using (var transaction = Connection.BeginTransaction())
            {
                //Company
                Guid companyId = await CreateCompany(createCompanyDto);

                //Company Adress
                await CreateCompanyAdress(companyId, createCompanyDto.CompanyAdressDto);

                //Company Contact
                await CreaCompanyContact(companyId, createCompanyDto.CompanyContactDto);

                transaction.Commit();
            }
        }

        public async Task<Guid> CreateCompany(CreateCompanyDto createCompanyDto) 
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into companies");
            sql.Append("(");
            sql.Append("company_id,");
            sql.Append("rfc,");
            sql.Append("comercial_name,");
            sql.Append("business_name,");
            sql.Append("active,");
            sql.Append("group_id,");
            sql.Append("member_id");
            sql.Append(") ");
            sql.Append("values");
            sql.Append("(");
            sql.Append("@company_id,");
            sql.Append("@rfc,");
            sql.Append("@comercial_name,");
            sql.Append("@business_name,");
            sql.Append("@active,");
            sql.Append("@group_id,");
            sql.Append("@member_id");
            sql.Append(") ");
            sql.Append("RETURNING company_id; ");

            Guid companyId = await Connection
                .ExecuteScalarAsync<Guid>(
                    sql.ToString(),
                    new {
                        company_id = Guid.NewGuid(),
                        rfc = createCompanyDto.CompanyDto.RFC,
                        comercial_name = createCompanyDto.CompanyDto.ComercialName,
                        business_name = createCompanyDto.CompanyDto.BusinessName,
                        active = true,
                        group_id = createCompanyDto.CompanyDto.GroupId,
                        member_id = createCompanyDto.MemberId
                    }
                );

            return companyId;
        }

        public async Task CreateCompanyAdress(Guid companyId,CompanyAdressDto companyAdressDto)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into company_adress ");
            sql.Append("(");
            sql.Append("company_adress_id,");
            sql.Append("street,");
            sql.Append("number,");
            sql.Append("internal_number,");
            sql.Append("d_codigo,");
            sql.Append("company_id");
            sql.Append(") ");
            sql.Append("values ");
            sql.Append("(");
            sql.Append("@company_adress_id,");
            sql.Append("@street,");
            sql.Append("@number,");
            sql.Append("@internal_number,");
            sql.Append("@d_codigo,");
            sql.Append("@company_id");
            sql.Append("); ");

            await Connection
                .ExecuteAsync(
                    sql.ToString(),
                    new
                    {
                        company_adress_id = Guid.NewGuid(),
                        street = companyAdressDto.Street,
                        number = companyAdressDto.Number,
                        internal_number = companyAdressDto.InternalNumber,
                        d_codigo = companyAdressDto.PostalCode,
                        company_id = companyId
                    }
                );

        }

        public async Task CreaCompanyContact(Guid companyId, CompanyContactDto companyContactDto) 
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into company_contact ");
            sql.Append("(");
            sql.Append("company_contact_id,");
            sql.Append("contact_name,");
            sql.Append("email,");
            sql.Append("phone,");
            sql.Append("web_site,");
            sql.Append("company_id");
            sql.Append(")");
            sql.Append("values ");
            sql.Append("(");
            sql.Append("@company_contact_id,");
            sql.Append("@contact_name,");
            sql.Append("@email,");
            sql.Append("@phone,");
            sql.Append("@web_site,");
            sql.Append("@company_id");
            sql.Append(")");


            await Connection
            .ExecuteAsync(
                sql.ToString(),
                new
                {
                    company_contact_id = Guid.NewGuid(),
                    contact_name = companyContactDto.ContactName,
                    email = companyContactDto.Email,
                    phone = companyContactDto.Phone,
                    web_site = companyContactDto.WebSite,
                    company_id = companyId
                }
            );

        }
    }
}
