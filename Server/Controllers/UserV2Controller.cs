using Asp.Versioning;

namespace Hepra_testing_Mudblazor.Server.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserV2Controller : ControllerBase
    {
        private readonly IUserService _userService;

        public UserV2Controller(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var users = await _userService.GetUsers();

            foreach (var user in users)
            {
                user.Name = "V2";
                user.Surname = "V2";
                user.Email = "V2";
                user.TaxNumber = "V2";
                user.PhoneNumber = "V2";
            }

            return Ok(users);
        }
    }
}
