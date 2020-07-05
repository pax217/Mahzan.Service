using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.DataAccess.DTO.SalesDepartments.CreateSalesDepartmentsFull
{
    public class CreateSalsesSectionsFullDto
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public Guid SaleAreaId { get; set; }

        public List<CreateSalesCategoriesFullDto> ListCreateSalesCategoriesFullDto { get; set; }
    }
}
