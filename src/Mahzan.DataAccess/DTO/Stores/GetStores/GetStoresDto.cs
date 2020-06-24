using Mahzan.DataAccess.DTO._Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.DataAccess.DTO.Stores.GetStores
{
    public class GetStoresDto:BaseDto
    {
        public Guid? StoreId { get; set; }

        public string Name { get; set; }
    }
}
