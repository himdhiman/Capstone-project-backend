using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineBank.API.Interfaces;
using OnlineBank.API.Models;
using OnlineBank.API.Models.DTOs;

namespace OnlineBank.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CheckBalanceController : ControllerBase
    {
        private readonly IUserRepository _userDetails;
        private readonly IMapper _mapper;

        public CheckBalanceController(IDataService dataService, IMapper mapper)
        {
            _userDetails = dataService.UsersDataObject;
            _mapper = mapper;
        }


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
