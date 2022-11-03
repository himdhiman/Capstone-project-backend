using Microsoft.AspNetCore.Mvc;
using OnlineBank.API.Models;
using OnlineBank.API.Services;

namespace OnlineBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UsersService _usersService;

        public UserController(UsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<List<User>> Get() => await _usersService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<User>> Get(string id)
        {
            var user = await _usersService.GetAsync(id);
            if (user is null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost]
        public async Task<IActionResult> Post(User newUser)
        {
            await _usersService.CreateAsync(newUser);

            return NoContent();
        }


    }
}
