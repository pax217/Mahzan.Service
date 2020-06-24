using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.DataAccess.Exceptions.Groups.CreateGroup
{
    public class CreateGroupArgumentException : ArgumentException
    {
        public CreateGroupArgumentException(string message) : base(message)
        {
        }
    }
}
