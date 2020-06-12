using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.DataAccess.Exceptions.Users.Login
{
    public class LoginInvalidOperationException : InvalidOperationException
    {
        public LoginInvalidOperationException(string message) : base(message)
        {
        }
    }
}
