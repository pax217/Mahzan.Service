using Mahzan.Business.Events._Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Business.Events.Groups
{
    public class CreateGroupEvent:BaseEvent
    {
        public string Name { get; set; }
    }
}
