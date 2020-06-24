using Mahzan.Api.Filters._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Filters.Stores.GetStores
{
    public class GetStoresFilter:BaseFilter
    {
        public Guid? StoreId { get; set; }

        public string Name { get; set; }
    }
}
