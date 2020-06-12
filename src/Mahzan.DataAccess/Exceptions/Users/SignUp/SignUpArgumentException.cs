using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.DataAccess.Exceptions.Users.SignUp
{
    public class SignUpArgumentException : ArgumentException
    {
        public SignUpArgumentException(string message) : base(message)
        {
        }
    }
}
