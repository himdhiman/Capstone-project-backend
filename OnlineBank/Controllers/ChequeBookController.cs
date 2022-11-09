
using Microsoft.AspNetCore.Mvc;
using OnlineBank.API.Interfaces;
using OnlineBank.API.Models;
using OnlineBank.API.Models.DTOs;

namespace OnlineBank.API.Controllers
{
    //Controller for Cheque Book, integrated with the API
    [Route("api/[controller]")]
    [ApiController]
    public class ChequeBookController :ControllerBase
    {

        //Objects of respective interfaces
        private readonly IUserRepository _userDetails;
        private readonly IChequeBookRepo _chqBook;

        //mapping objects using AutoMapper Service in C#
        public ChequeBookController(IDataService dataService)
            {
                _userDetails = dataService.UsersDataObject;
                _chqBook = dataService.CheckBookDetailsDataObject;
              
            }

        //implementing multi-threading for parallel requests
        //Validation applied for length of Account number 
        [HttpGet("{accno:length(10)}")]
        public async Task<ActionResult> Get(long accno)
        {
            var userDetails = await _userDetails.GetAsyncByAccountNumber(accno);
            if (userDetails is null)
            {
                return BadRequest("Account Number does not exist");
            }
            Random rnd = new Random();
            ChequeBookDetails chq = new ChequeBookDetails();
            chq.AccountNumber = accno;
            chq.RequestedDate = DateTime.Today;
            chq.IssueDate = DateTime.Today.AddDays(rnd.Next(1,8));
            chq.Priority = rnd.Next(1,31);

            await _chqBook.CreateAsync(chq);

            return Ok("Cheque Book request raised Successfully");


        }
    }
}
