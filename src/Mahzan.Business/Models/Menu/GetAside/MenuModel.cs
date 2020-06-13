using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Mahzan.Business.Models.Menu.GetAside
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class MenuModel
    {
        public List<MenuSection> Aside = new List<MenuSection>();
    }

    public class MenuSection 
    {
        public Guid? MenuSectionId { get; set; }

        public Guid? MenuSelectionId { get; set; }

        public string Section { get; set; }

        public string Title { get; set; }

        public bool Root { get; set; }

        public string Bullet { get; set; }

        public string Icon { get; set; }

        public List<SubMenu> Submenu = new List<SubMenu>();
    }

    public class SubMenu 
    {
        public Guid MenuSubMenuId { get; set; }
        public string Title { get; set; }
        public string Bullet { get; set; }
        public string Page { get; set; }
    }
}
