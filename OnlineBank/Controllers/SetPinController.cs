using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineBank.API.Interfaces;
using OnlineBank.API.Models;
using OnlineBank.API.Models.DTOs;

namespace OnlineBank.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SetPinController: ControllerBase
    {
        private readonly IAtmDetailsRepository _userService;
        private readonly IUserRepository _userDetails;
        private readonly IMapper _mapper;

        public SetPinController(IDataService dataService, IMapper mapper)
        {
            _userService = dataService.AtmDetailsDataObject;
            _userDetails = dataService.UsersDataObject;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(AtmPinDTO atm_details)
        {
               
            var accno =  atm_details.AccountNumber;
            var pin = atm_details.AtmPin;
            var p = pin.ToString();
            var a = accno.ToString();
            if(p.Length != 4)
            {
                return BadRequest("Please enter 4 digit pin");
            }

            if(a.Length != 10)
            {
                return BadRequest("Please enter 10 digit account number");
            }
          

            var user_details = await _userDetails.GetAsyncByAccountNumber(accno);
            var user_service = await _userService.GetAsync(accno);
            if (user_details == null)
            {
                return BadRequest("Account Number does not exist!");

            }

            if(user_service != null)
            {
                return Ok("Pen already set!");
            }

            AtmDetails atm = _mapper.Map<AtmDetails>(atm_details);
            await _userService.CreateAsync(atm);

            return NoContent();

        }



    }
}
