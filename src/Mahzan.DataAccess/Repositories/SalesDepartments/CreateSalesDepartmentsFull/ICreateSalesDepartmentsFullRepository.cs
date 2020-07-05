using Mahzan.DataAccess.DTO.SalesDepartments.CreateSalesDepartmentsFull;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Repositories.SalesDepartments.CreateSalesDepartmentsFull
{
    public interface ICreateSalesDepartmentsFullRepository
    {
        Task HandleRepository(
            CreateSalesDepartmentsFullDto createSalesDepartmentsFullDto,
            Guid memberId);

    }
}
