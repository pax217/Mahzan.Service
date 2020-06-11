using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Business.Events._Base
{
    public class BaseEvent
    {
        public Guid MembersId { get; set; }
        public Guid AspNetUserId { get; set; }
    }
}
