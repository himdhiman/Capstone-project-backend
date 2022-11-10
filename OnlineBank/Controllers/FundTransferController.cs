using Microsoft.AspNetCore.Mvc;
using OnlineBank.API.Interfaces;
using OnlineBank.API.Models.DTOs;
using OnlineBank.API.Models;
using AutoMapper;
using OnlineBank.API.Validators;

namespace OnlineBank.API.Controllers
{
    //Controller for Fund Transfer, integrated with the API
    [Route("api/[controller]")]
    [ApiController]
    public class FundTransferController : ControllerBase
    {
        //Objects of respective interfaces
        private readonly IUserRepository _usersService;
        private readonly IFundTransferRepository _fundTransferService;
        private readonly ITransactionRepository _transactionService;
        private readonly IMapper _mapper;

        //mapping objects using AutoMapper Service in C#
        public FundTransferController(IDataService dataservice, IMapper mapper)
        {
            _usersService = dataservice.UsersDataObject;
            _mapper = mapper;
            _fundTransferService = dataservice.FundTransferDataObject;
            _transactionService = dataservice.TransactionDataObject;
        }

        //implementing multi-threading for parallel requests
        [HttpPost]
        public async Task<IActionResult> Transfer(FundTransferDTO newFundTransfer)
        {
            bool isValid = await FundTransferObjectValidator.Validate(_usersService, newFundTransfer);
            if (!isValid)
            {
                return BadRequest("Invalid Data");
            }
            FundTransfer fundTransfer = _mapper.Map<FundTransfer>(newFundTransfer);
            Transaction transactionSource = _mapper.Map<Transaction>(fundTransfer);
            transactionSource.Credited = false;
            Transaction transactionDestination = _mapper.Map<Transaction>(fundTransfer);
            transactionDestination.AccountNumber = newFundTransfer.destinationAccountNumber;
            transactionDestination.Credited = true;

            await _fundTransferService.CreateAsync(fundTransfer);
            await _transactionService.CreateAsync(transactionSource);
            await _transactionService.CreateAsync(transactionDestination);

            return NoContent();
        }
    }
}
