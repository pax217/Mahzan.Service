using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Models.Entities
{
    public class Stores
    {
        public Guid storeId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Comment { get; set; }

        public bool Active { get; set; }

        public Guid CompanyId { get; set; }

        public Guid MemberId { get; set; }
    }
}
