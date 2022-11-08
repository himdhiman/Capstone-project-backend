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
        private readonly IUserRepository _usersService;
        private readonly IMapper _mapper;

        public UserController(IDataService dataService, IMapper mapper)
        {
            _usersService = dataService.UsersDataObject;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<UserReturnObject>> Get()
        {
            var users = await _usersService.GetAsync();
            List<UserReturnObject> ReturnData = _mapper.Map<List<UserReturnObject>>(users);
            return ReturnData;

        }
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<UserReturnObject>> Get(string id)
        {
            var user = await _usersService.GetAsync(id);
            if (user is null)
            {
                return NotFound();
            }
            UserReturnObject ReturnData = _mapper.Map<UserReturnObject>(user);
            return ReturnData;
        }

        [HttpGet("{accno:length(10)}")]
        public async Task<ActionResult<UserReturnObject>> Get(long accno)
        {
            var user = await _usersService.GetAsyncByAccountNumber(accno);
            if (user is null)
            {
                return NotFound();
            }
            UserReturnObject ReturnData = _mapper.Map<UserReturnObject>(user);
            return ReturnData;
        }

        [HttpPost]
        public async Task<ActionResult<AccountNumberDTO>> Post(UserDTO newUser)
        {
            User user = _mapper.Map<User>(newUser);
            await _usersService.CreateAsync(user);

            AccountNumberDTO ReturnObject = _mapper.Map<AccountNumberDTO>(user);
            return ReturnObject;
        }
    }
}
