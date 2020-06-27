using Mahzan.DataAccess.DTO.SalesUnits.CreateSaleUnit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Repositories.SalesUnits.CreateSaleUnit
{
    public interface ICreateSaleUnitRepository
    {
        Task HandleRepository(CreateSaleUnitDto createSaleUnitDto);
    }
}
