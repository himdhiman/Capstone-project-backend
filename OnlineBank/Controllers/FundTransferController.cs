using Microsoft.AspNetCore.Mvc;
using OnlineBank.API.Interfaces;
using OnlineBank.API.Models.DTOs;
using OnlineBank.API.Models;
using AutoMapper;
using OnlineBank.API.Validators;

namespace OnlineBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FundTransferController : ControllerBase
    {
        private readonly IUserRepository _usersService;
        private readonly IFundTransferRepository _fundTransferService;
        private readonly ITransactionRepository _transactionService;
        private readonly IMapper _mapper;

        public FundTransferController(IDataService dataservice, IMapper mapper)
        {
            _usersService = dataservice.UsersDataObject;
            _mapper = mapper;
            _fundTransferService = dataservice.FundTransferDataObject;
            _transactionService = dataservice.TransactionDataObject;
        }

        [HttpPost]
        public async Task<IActionResult> Transfer(FundTransferDTO newFundTransfer)
        {
            bool isValid = await FundTransferObjectValidator.Validate(_usersService, newFundTransfer);
            if (!isValid)
            {
                return BadRequest("Invalid Data");
            }
            FundTransfer fundTransfer = _mapper.Map<FundTransfer>(newFundTransfer);
            Transaction transaction = _mapper.Map<Transaction>(fundTransfer);

            await _fundTransferService.CreateAsync(fundTransfer);
            await _transactionService.CreateAsync(transaction); 

            return NoContent();
        }
    }
}
