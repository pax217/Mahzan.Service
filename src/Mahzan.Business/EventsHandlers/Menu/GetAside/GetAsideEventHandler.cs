using Mahzan.Business.Events.Menu.GetAside;
using Mahzan.Business.Models.Menu.GetAside;
using Mahzan.DataAccess.Repositories.Menu.GetAside;
using Mahzan.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Business.EventsHandlers.Menu.GetAside
{
    public class GetAsideEventHandler : IGetAsideEventHandler
    {
        private readonly IGetAsideRepository _getAsideRepository;

        public GetAsideEventHandler(
            IGetAsideRepository getAsideRepository)
        {
            _getAsideRepository = getAsideRepository;
        }

        public async Task<MenuModel> HandleEvent(GetAsideEvent getAsideEvent)
        {
            MenuModel menu = new MenuModel();

            List<Menu_Role> menuRole = await _getAsideRepository
                .GetMenuRole(getAsideEvent.RoleId);

            foreach (var item in menuRole)
            {

                //Section
                if (item.MenuSectionId != null 
                    && item.MenuSelectionId == null)
                {
                    MenuSection section = new MenuSection();
                    section = await BuildSection(item);

                    menu.Aside.Add(section);
                }

                //Selection
                if (item.MenuSectionId != null
                    && item.MenuSelectionId != null
                    && item.MenuSubMenuId == null)
                {
                    MenuSection section = new MenuSection();
                    section = await BuildSelection(item);

                    menu.Aside.Add(section);
                }

                //Submenu
                if (item.MenuSectionId != null
                    && item.MenuSelectionId != null
                    && item.MenuSubMenuId != null)
                {
                    MenuSection sectionExist = (from ms in menu.Aside
                                                where ms.MenuSelectionId == item.MenuSelectionId
                                                select ms)
                                                .FirstOrDefault();

                    sectionExist.Submenu.Add(await BuildSubMenu(item));
                }
            }



            return menu;
        }

        public async Task<MenuSection> BuildSection(Menu_Role menuRole) 
        {

            Menu_Sections section = await _getAsideRepository
                .GetSection(menuRole.MenuSectionId.Value);

            return new MenuSection {
                MenuSectionId = section.MenuSectionId,
                Section = section.Section
            };
        }

        public async Task<MenuSection> BuildSelection(Menu_Role menuRole) 
        {
            Menu_Selections selection = await _getAsideRepository
                .GetSelection(menuRole.MenuSelectionId.Value);

            return new MenuSection
            {
                MenuSelectionId = selection.MenuSelectionId,
                Title = selection.Title,
                Root = selection.Root,
                Bullet =selection.Bullet,
                Icon = selection.Icon
            };
        }

        public async Task<SubMenu> BuildSubMenu(Menu_Role menuRole) 
        {
            Menu_Sub_Menu subMenu = await _getAsideRepository
                .GetSubMenu(menuRole.MenuSubMenuId.Value);

            return new SubMenu
            {
                MenuSubMenuId = subMenu.MenuSubMenuId,
                Title = subMenu.Title,
                Page = subMenu.Page,
                Bullet = subMenu.Bullet
            };
        }
    }
}
