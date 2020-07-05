using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.DataAccess.DTO.SalesDepartments.CreateSalesDepartmentsFull
{
    public class CreateSaleAreasFullDto
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public Guid SaleDepartment { get; set; }

        public List<CreateSalsesSectionsFullDto> ListCreateSalsesSectionsFullDto { get; set; }
    }
}
