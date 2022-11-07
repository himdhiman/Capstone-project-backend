
using Microsoft.AspNetCore.Mvc;
using OnlineBank.API.Interfaces;
using OnlineBank.API.Models;
using OnlineBank.API.Models.DTOs;

namespace OnlineBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChequeBookController :ControllerBase
    {
            private readonly IUserRepository _userDetails;
            private readonly IChequeBookRepo _chqBook;

            public ChequeBookController(IDataService dataService)
            {
                _userDetails = dataService.UsersDataObject;
                _chqBook = dataService.CheckBookDetailsDataObject;
              
            }


        [HttpPost("{accno:length(10)}")]
        public async Task<ActionResult> Post(long accno)
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
