using Mahzan.DataAccess.DTO._Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.DataAccess.DTO.Stores.CreateStore
{
    public class CreateStoreDto:BaseDto
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Comment { get; set; }

        public Guid CompanyId { get; set; }
    }
}
