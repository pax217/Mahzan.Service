using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Business.Exceptions.Users.Login
{
    public class LoginArgumentException : ArgumentException
    {
        public LoginArgumentException(string message) : base(message)
        {
        }
    }
}
