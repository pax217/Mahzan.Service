﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Exceptions
{
    public class ServiceKeyNotFoundException : KeyNotFoundException
    {
        public ServiceKeyNotFoundException(string message, Exception exception)
            : base(message, exception)
        { }

        public ServiceKeyNotFoundException(Exception exception)
            : this(exception.Message, exception)
        { }
    }
}
