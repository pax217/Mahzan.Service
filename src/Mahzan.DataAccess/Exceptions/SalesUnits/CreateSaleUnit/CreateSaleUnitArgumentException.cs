using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.DataAccess.Exceptions.SalesUnits.CreateSaleUnit
{
    public class CreateSaleUnitArgumentException : ArgumentException
    {
        public CreateSaleUnitArgumentException(string message) : base(message)
        {
        }
    }
}
