using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Commands.SalesDepartments.CreateSaleDepartmentFull
{
    public class CreateSalesDepartmentFullCommand
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public List<CreateSaleAreasFullCommand> ListCreateSaleAreasFullCommand { get; set; }
    }
}
