namespace Hepra_testing_Mudblazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Group>>> GetGroups()
        {
            var result = await _groupService.GetGroups();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Group>> GetGroupById(int id)
        {
            var result = await _groupService.GetGroupById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Group>>> AddGroup(Group group)
        {
            var result = await _groupService.AddGroup(group);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<Group>>> UpdateGroup(Group group)
        {
            var result = await _groupService.UpdateGroup(group);
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<List<Group>>> DeleteGroupById(int id)
        {
            var result = await _groupService.DeleteGroupById(id);
            return Ok(result);
        }
    }
}
