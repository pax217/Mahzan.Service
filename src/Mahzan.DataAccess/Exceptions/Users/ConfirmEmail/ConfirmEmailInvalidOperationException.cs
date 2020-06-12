using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.DataAccess.Exceptions.Users.ConfirmEmail
{
    public class ConfirmEmailInvalidOperationException : InvalidOperationException
    {
        public ConfirmEmailInvalidOperationException(string message) : base(message)
        {
        }
    }
}
