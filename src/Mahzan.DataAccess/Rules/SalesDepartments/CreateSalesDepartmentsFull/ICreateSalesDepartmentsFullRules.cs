using Mahzan.DataAccess.DTO.SalesDepartments.CreateSalesDepartmentsFull;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Rules.SalesDepartments.CreateSalesDepartmentsFull
{
    public interface ICreateSalesDepartmentsFullRules
    {
        Task HandleRules(
            CreateSalesDepartmentsFullDto createSalesDepartmentsFullDto,
            Guid memberId);
    }
}
