using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineBank.API.Interfaces;
using OnlineBank.API.Models;
using OnlineBank.API.Models.DTOs;

namespace OnlineBank.API.Controllers
{
    //Controller for Check Balance, integrated with the API
    [Route("api/[controller]")]
    [ApiController]
    public class CheckBalanceController : ControllerBase
    {
        //Objects of respective interfaces
        private readonly IUserRepository _userDetails;
        private readonly IMapper _mapper;

        //mapping objects using AutoMapper Service in C#
        public CheckBalanceController(IDataService dataService, IMapper mapper)
        {
            _userDetails = dataService.UsersDataObject;
            _mapper = mapper;
        }

        //implementing multi-threading for parallel requests
        //Validation applied for length of Account number
        [HttpGet("{accno:length(10)}")]
        public async Task<ActionResult<AccountBalanceReturnObject>> Get(long accno)
        {
            var userDetails = await _userDetails.GetAsyncByAccountNumber(accno);
            if (userDetails is null)
            {
                return NotFound();
            }
            AccountBalanceReturnObject returnObject = _mapper.Map<AccountBalanceReturnObject>(userDetails);
            return returnObject;
        }
    }
}
