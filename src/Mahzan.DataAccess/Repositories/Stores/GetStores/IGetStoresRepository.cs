using Mahzan.DataAccess.DTO.Stores.GetStores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Repositories.Stores.GetStores
{
    public interface IGetStoresRepository
    {
        Task<List<Models.Entities.Stores>> HandleRepository(GetStoresDto getStoresDto);
    }
}
