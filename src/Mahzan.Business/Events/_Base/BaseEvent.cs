﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Business.Events._Base
{
    public class BaseEvent
    {
        public Guid MemberId { get; set; }
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}
