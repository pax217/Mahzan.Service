using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Repositories.Menu.GetAside
{
    public interface IGetAsideRepository
    {
        Task<List<Models.Entities.Menu_Role>> GetMenuRole(Guid roleId);

        Task<Models.Entities.Menu_Sections> GetSection(Guid menuSectionId);

        Task<Models.Entities.Menu_Selections> GetSelection(Guid menuSelectionId);

        Task<Models.Entities.Menu_Sub_Menu> GetSubMenu(Guid menuSubMeniId);
    }
}
