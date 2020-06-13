using Dapper;
using Mahzan.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Repositories.Menu.GetAside
{
    public class GetAsideRepository :DataConnection, IGetAsideRepository
    {
        public GetAsideRepository(
            IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task<List<Menu_Role>> GetMenuRole(Guid roleId)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Select * from menu_role ");
            sql.Append("Where role_id = @role_id ");
            sql.Append("Order by \"order\" ");

            IEnumerable<Menu_Role> menuRole;
            menuRole = await Connection
                .QueryAsync<Menu_Role>(
                    sql.ToString(),
                    new
                    {
                        role_id = roleId
                    }
                );

            return menuRole.ToList();
        }

        public async Task<Menu_Sections> GetSection(Guid menuSectionId)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Select * from menu_sections ");
            sql.Append("Where menu_section_id = @menu_section_id ");

            IEnumerable<Menu_Sections> menuSections;
            menuSections = await Connection
                .QueryAsync<Menu_Sections>(
                    sql.ToString(),
                    new
                    {
                        menu_section_id = menuSectionId
                    }
                );

            return menuSections.FirstOrDefault();
        }

        public async Task<Menu_Selections> GetSelection(Guid menuSelectionId)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Select * from menu_selections ");
            sql.Append("Where menu_selection_id = @menu_selection_id ");

            IEnumerable<Menu_Selections> menuSelections;
            menuSelections = await Connection
                .QueryAsync<Menu_Selections>(
                    sql.ToString(),
                    new
                    {
                        menu_selection_id = menuSelectionId
                    }
                );

            return menuSelections.FirstOrDefault();
        }

        public async Task<Menu_Sub_Menu> GetSubMenu(Guid menuSubMenuId)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("Select * from menu_sub_menu ");
            sql.Append("Where menu_sub_menu_id = @menu_sub_menu_id ");

            IEnumerable<Menu_Sub_Menu> menuSubMenus;
            menuSubMenus = await Connection
                .QueryAsync<Menu_Sub_Menu>(
                    sql.ToString(),
                    new
                    {
                        menu_sub_menu_id = menuSubMenuId
                    }
                );

            return menuSubMenus.FirstOrDefault();
        }
    }
}
