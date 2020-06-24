using Dapper;
using Mahzan.DataAccess.DTO.Companies.CreateCompany;
using Mahzan.DataAccess.Exceptions.Companies.CreateCompany;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Rules.Companies.CreateCompany
{
    public class CreateCompanyRules : DataConnection, ICreateCompanyRules
    {
        public CreateCompanyRules(
            IDbConnection dbConnection) : base(dbConnection)
        {

        }


        public async Task HandleRules(CreateCompanyDto createCompanyDto)
        {
            //Valida que el grupoId exista
            if (! await GroupIdExist(
                createCompanyDto.MemberId, 
                createCompanyDto.CompanyDto.GroupId)
                )
            {
                throw new CreateCompanyArgumentException(
                    $"El Grupo con id {createCompanyDto.CompanyDto.GroupId} no existe."
                    );
            }

            //Valida que el rfc no exista
            if (await RFCExist(
                    createCompanyDto.MemberId, 
                    createCompanyDto.CompanyDto.RFC)
                )
            {
                throw new CreateCompanyArgumentException(
                    $"El RFC {createCompanyDto.CompanyDto.RFC} ya existe"
                    );
            }

            //Valuda que el código postal exista
            if (await PostalCodeExist(createCompanyDto.CompanyAdressDto.PostalCode))
            {
                throw new CreateCompanyArgumentException(
                    $"El Código Postal {createCompanyDto.CompanyAdressDto.PostalCode} no existe."
                    );
            }

        }

        public async Task<bool> RFCExist(Guid memberId,string rfc) 
        {
            bool result = false;

            StringBuilder sql = new StringBuilder();
            sql.Append("select * from companies ");
            sql.Append("where   member_id = @member_id ");
            sql.Append("and    rfc = @rfc ");

            IEnumerable<Models.Entities.Companies> companies;
            companies = await Connection
                .QueryAsync<Models.Entities.Companies>(
                  sql.ToString(),
                  new
                  {
                      member_id = memberId,
                      rfc = rfc
                  }
                );

            if (companies.Any())
            {
                result = true;
            }

            return result;
        }

        public async Task<bool> GroupIdExist(Guid memberId, Guid groupId) 
        {
            bool result = false;

            StringBuilder sql = new StringBuilder();
            sql.Append("select * from groups ");
            sql.Append("where   member_id = @member_id ");
            sql.Append("and    group_id = @group_id ");

            IEnumerable<Models.Entities.Groups> groups;
            groups = await Connection
                .QueryAsync<Models.Entities.Groups>(
                  sql.ToString(),
                  new
                  {
                      member_id = memberId,
                      group_id = groupId
                  }
                );

            if (groups.Any())
            {
                result = true;
            }

            return result;
        }

        public async Task<bool> PostalCodeExist(string d_codigo) 
        {
            bool result = false;

            StringBuilder sql = new StringBuilder();
            sql.Append("select * from postal_codes ");
            sql.Append("where   d_codigo = @d_codigo ");

            IEnumerable<Models.Entities.Postal_Codes> postalCodes;
            postalCodes = await Connection
                .QueryAsync<Models.Entities.Postal_Codes>(
                  sql.ToString(),
                  new
                  {
                      d_codigo = d_codigo
                  }
                );

            if (postalCodes.Any())
            {
                result = true;
            }

            return result;
        }
    }
}
