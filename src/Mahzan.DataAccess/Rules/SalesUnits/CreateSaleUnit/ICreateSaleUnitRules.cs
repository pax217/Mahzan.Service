using Mahzan.DataAccess.DTO.SalesUnits.CreateSaleUnit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Rules.SalesUnits.CreateSaleUnit
{
    public interface ICreateSaleUnitRules
    {
        Task HandleRules(CreateSaleUnitDto createSaleUnitDto);

    }
}
