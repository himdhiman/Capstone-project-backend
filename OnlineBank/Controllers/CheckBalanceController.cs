using Microsoft.AspNetCore.Mvc;
using OnlineBank.API.Interfaces;
using OnlineBank.API.Models;

namespace OnlineBank.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CheckBalanceController : ControllerBase
    {
        private readonly IAccountBalance<AtmDetails> _usersService;

        public CheckBalanceController(IDataService dataService)
        {
            _usersService = dataService.BalanceDetailsObject;
        }


        [HttpGet("{acnt:length(4)}")]
        public async Task<ActionResult<AtmDetails>> Get(long acnt)
        {
            var user = await _usersService.GetAsync(acnt);
            if (user is null)
            {
                return NotFound();
            }
            return user;
        }


    }
}
