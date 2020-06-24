using Mahzan.DataAccess.DTO._Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.DataAccess.DTO.Goups
{
    public class GetGroupsDto:BaseDto
    {
        public Guid? GroupId { get; set; }

        public string Name { get; set; }
    }
}
