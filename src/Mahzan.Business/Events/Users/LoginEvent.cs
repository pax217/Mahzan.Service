﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Business.Events.Users
{
    public class LoginEvent
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
