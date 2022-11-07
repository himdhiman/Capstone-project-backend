using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineBank.API.Interfaces;
using OnlineBank.API.Models;
using OnlineBank.API.Models.DTOs;

namespace OnlineBank.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ChangePinController : ControllerBase
    {
        private readonly IAtmDetailsRepository atmDetailsService;
        private readonly IUserRepository _userDetails;

        public ChangePinController(IDataService dataService, IMapper mapper)
        {
            atmDetailsService = dataService.AtmDetailsDataObject;
            _userDetails = dataService.UsersDataObject;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ChangePinDTO atm_details)
        {

            var accno = atm_details.AccountNumber;
            var old_pin = atm_details.Pin; // old pin
            var new_pin = atm_details.NewPin;

            var p1 = old_pin.ToString();
            var p2 = new_pin.ToString();
            var a = accno.ToString();
            if (p1.Length != 4 || p2.Length != 4)
            {
                return BadRequest("Entered pins should be 4 digits in length");
            }

            if (a.Length != 10)
            {
                return BadRequest("Please enter 10 digit account number");
            }


            var user_details = await _userDetails.GetAsyncByAccountNumber(accno);
            var user_service = await atmDetailsService.GetAsync(accno);
            if (user_details == null)
            {
                return BadRequest("Account Number does not exist");

            }

            if (user_service == null)
            {
                return BadRequest("Pin is not set for the account number. Please set the pin using SetPin option");
            }

            var chk_pin = await atmDetailsService.GetAsync(old_pin,accno);
            if (chk_pin == null)
            {
                return BadRequest("Entered Pin does not match the current pin");
            }

            await atmDetailsService.UpdateAsync(accno, new_pin); 
            return Ok("Pin changed sucessfully");

        }
    }
}