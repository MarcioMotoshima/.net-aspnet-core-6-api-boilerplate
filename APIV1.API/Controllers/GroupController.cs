
using APIV1.Domain;
using APIV1.Domain.Dto;
using APIV1.Persistence;
using APIV1.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace APIV1.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : Controller
    {
        private readonly IPersistenceGroup _groupPersistence;
        private readonly IGroupService _groupService;

        public GroupController(IPersistenceGroup groupPersistence, IGroupService groupService)
        {
            _groupPersistence = groupPersistence;
            _groupService = groupService;
        }

        [HttpGet]
        public async Task<ActionResult<Group>> Get()
        {
            return Ok(new { groups = await _groupService.Get() });
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> GetById(int id)
        {
            Group? group = await _groupService.GetById(id);
            if (group == null)
            {
                return NotFound("Not Found");
            }
            return Ok(new { group = group });
        }

        [HttpPost]
        public async Task<ActionResult<Group>> Create([FromBody] GroupCreateDto request)
        {
            if (request == null)
            {
                return BadRequest(new { message = "Invalid request." });
            }
            var group = await _groupService.Create(request);
            if (group != null)
            {
                return Ok(new { group = group });
            }
            return BadRequest(new { message = "Group with the same name already exists." });
        }
    }
}