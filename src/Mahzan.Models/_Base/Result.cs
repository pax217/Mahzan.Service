using Mahzan.Models.Enums.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Models._Base
{
    public class Result
    {
        public bool IsValid { get; set; }
        public ResultTypeEnum ResultTypeEnum { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
