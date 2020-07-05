using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.DataAccess.DTO.SalesDepartments.CreateSalesDepartmentsFull
{
    public class CreateSalesDepartmentFullDto
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public List<CreateSaleAreasFullDto> ListCreateSaleAreasFullDto { get; set; }
    }
}
