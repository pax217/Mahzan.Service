using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Models.Entities
{
    public class Menu_Sub_Menu
    {
        public Guid MenuSubMenuId { get; set; }
        public string Title { get; set; }
        public string Bullet { get; set; }
        public Guid MenuSelectionId { get; set; }
    }
}
