using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Models.Entities
{
    public class Menu_Sub_Menu_Items
    {
        public Guid MenusubMenuItemId { get; set; }

        public string Title { get; set; }

        public string Page { get; set; }

        public Guid MenuSubMenuId { get; set; }
    }
}
