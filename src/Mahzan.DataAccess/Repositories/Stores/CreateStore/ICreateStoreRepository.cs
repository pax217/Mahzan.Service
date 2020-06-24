using Mahzan.DataAccess.DTO.Stores.CreateStore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Repositories.Stores.CreateStore
{
    public interface ICreateStoreRepository
    {
        Task HandleRepository(CreateStoreDto createStoreDto);
    }
}
