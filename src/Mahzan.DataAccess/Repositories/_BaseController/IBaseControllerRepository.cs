using Mahzan.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Repositories._BaseController
{
    public interface IBaseControllerRepository
    {
        User_Role GetRole(string userName);
    }
}
