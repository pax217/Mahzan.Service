using Mahzan.DataAccess.DTO.PointsOfSale.CreatePointOfSale;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Repositories.PointsOfSale.CreatePointOfSale
{
    public interface ICreatePointOfSaleRepository
    {
        Task HandleRepository(CreatePointOfSaleDto createPointOfSaleDto);
    }
}
