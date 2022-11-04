using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineBank.API.Interfaces;
using OnlineBank.API.Models;
using OnlineBank.API.Models.DTOs;

namespace OnlineBank.API.Controllers
{
    [Route("api/users/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _usersService;
        private readonly IMapper _mapper;

        public UserController(IDataService dataService, IMapper mapper)
        {
            _usersService = dataService.UsersDataObject;
            _mapper = mapper;
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
        public async Task<IActionResult> Post(UserDTO newUser)
        {
            User user = _mapper.Map<User>(newUser);
            await _usersService.CreateAsync(user);

            return NoContent();
        }
    }
}
