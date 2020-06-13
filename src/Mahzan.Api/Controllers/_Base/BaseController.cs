using Mahzan.DataAccess.Repositories._BaseController;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Controllers._Base
{
    [ApiController]
    public class BaseController: Controller
    {
        private readonly IBaseControllerRepository _baseControllerRepository;

        public BaseController(
            IBaseControllerRepository baseControllerRepository) 
        {
            _baseControllerRepository = baseControllerRepository;
        }

        public Guid RoleId
        {
            get
            {
                return _baseControllerRepository
                       .GetRole(HttpContext.User.Claims.ToList()[0].Value)
                       .RoleId;
            }
        }
    }
}
