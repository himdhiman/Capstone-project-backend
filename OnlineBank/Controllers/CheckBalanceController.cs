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
        private readonly IAccountBalance<AtmDetails> _atmDetails;
        private readonly IMapper _mapper;

        public CheckBalanceController(IDataService dataService, IMapper mapper)
        {
            _atmDetails = dataService.BalanceDetailsObject;
            _mapper = mapper;
        }


        [HttpGet("{accno:length(10)}")]
        public async Task<ActionResult<AccountBalanceReturnObject>> Get(long accno)
        {
            var atmDetails = await _atmDetails.GetAsync(accno);
            if (atmDetails is null)
            {
                return NotFound();
            }
            AccountBalanceReturnObject returnObject = _mapper.Map<AccountBalanceReturnObject>(atmDetails);
            return returnObject;
        }
    }
}
