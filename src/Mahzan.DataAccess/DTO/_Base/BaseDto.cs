using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.DataAccess.DTO._Base
{
    public class BaseDto
    {
        public Guid MemberId { get; set; }
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}
