using Mahzan.Models._Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Business.Results.Users
{
    public class LoginResult:Result
    {
        public string Token { get; set; }
    }
}
