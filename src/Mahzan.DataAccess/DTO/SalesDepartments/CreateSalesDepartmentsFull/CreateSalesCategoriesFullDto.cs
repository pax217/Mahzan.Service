using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.DataAccess.DTO.SalesDepartments.CreateSalesDepartmentsFull
{
    public class CreateSalesCategoriesFullDto
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public Guid SaleSectionId { get; set; }
    }
}
