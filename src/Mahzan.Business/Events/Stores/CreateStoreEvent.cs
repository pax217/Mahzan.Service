using Mahzan.Business.Events._Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Business.Events.Stores
{
    public class CreateStoreEvent:BaseEvent
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Comment { get; set; }

        public Guid CompanyId { get; set; }
    }
}
