using Mahzan.DataAccess.DTO._Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.DataAccess.DTO.Companies.CreateCompany
{
    public class CreateCompanyDto:BaseDto
    {
        public CompanyDto CompanyDto { get; set; }

        public CompanyAdressDto CompanyAdressDto { get; set; }

        public CompanyContactDto CompanyContactDto { get; set; }

    }
}
