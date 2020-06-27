using Mahzan.DataAccess.DTO.PointsOfSale.GetPointsOfSale;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Repositories.PointsOfSale.GetPointsOfSale
{
    public interface IGetPointsOfSaleRepository
    {
        Task<List<Models.Entities.Points_Of_Sale>> HandleRepository(GetPointsOfSaleDto getPointsOfSaleDto);
    }
}
