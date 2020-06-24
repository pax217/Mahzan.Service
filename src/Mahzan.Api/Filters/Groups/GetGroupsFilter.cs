using Mahzan.Api.Filters._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Filters.Groups
{
    public class GetGroupsFilter: BaseFilter
    {
        public Guid? GroupId { get; set; }

        public string Name { get; set; }
    }
}
