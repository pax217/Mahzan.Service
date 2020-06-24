using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Models.Entities
{
    public class Groups
    {
        public Guid GroupId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public Guid MemberId { get; set; }
    }
}
