using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Api.Commands.Groups;
using Mahzan.Api.Controllers._Base;
using Mahzan.Api.Exceptions;
using Mahzan.Api.Filters.Groups;
using Mahzan.Business.Events.Groups;
using Mahzan.Business.EventsHandlers.Groups.Create;
using Mahzan.DataAccess.DTO.Goups;
using Mahzan.DataAccess.Repositories._BaseController;
using Mahzan.DataAccess.Repositories.Groups.GetGroups;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mahzan.Api.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : BaseController
    {
        private readonly ICreateGroupEventHandler _createGroupEventHandler;

        private readonly IGetGroupsRepository _getGroupsRepository;

        public GroupsController(
            IBaseControllerRepository baseControllerRepository,
            ICreateGroupEventHandler createGroupEventHandler, 
            IGetGroupsRepository getGroupsRepository) : base(baseControllerRepository)
        {
            _createGroupEventHandler = createGroupEventHandler;
            _getGroupsRepository = getGroupsRepository;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateGroupCommand command)
        {
            try
            {
                await _createGroupEventHandler
                    .HandleEvent(new CreateGroupEvent { 
                        Name = command.Name,
                        MemberId = MemberId
                    });
            }
            catch (ArgumentException ex)
            {

                throw new ServiceArgumentException(ex);
            }
            return Ok();
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery]GetGroupsFilter filter) 
        {
            List<Models.Entities.Groups> groups;

            try
            {
              groups= await _getGroupsRepository
                    .HandleRepository(new GetGroupsDto
                    {
                        GroupId = filter.GroupId,
                        Name = filter.Name,
                        MemberId = MemberId
                    });
            }
            catch (Exception ex)
            {

                throw;
            }

            return Ok(groups);
        }

    }
}
