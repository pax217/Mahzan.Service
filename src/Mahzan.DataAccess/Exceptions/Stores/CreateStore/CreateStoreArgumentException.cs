using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.DataAccess.Exceptions.Stores.CreateStore
{
    public class CreateStoreArgumentException : ArgumentException
    {
        public CreateStoreArgumentException(string message) : base(message)
        {
        }
    }
}
