using Mahzan.DataAccess.DTO.Stores.CreateStore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Rules.Stores
{
    public interface ICreateStoreRules
    {
        Task HandleRules(CreateStoreDto createStoreDto);
    }
}
