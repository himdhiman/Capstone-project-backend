using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineBank.API.Interfaces;
using OnlineBank.API.Models.DTOs;
using OnlineBank.API.Models;
using OnlineBank.API.Validators;

namespace OnlineBank.API.Controllers
{
    //Controller for Transaction, integrated with the API
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        //Objects of respective interfaces
        private readonly ITransactionRepository _transactionService;
        private readonly IMapper _mapper;

        //mapping objects using AutoMapper Service in C#
        public TransactionController(IDataService dataservice, IMapper mapper)
        {
            _mapper = mapper;
            _transactionService = dataservice.TransactionDataObject;
        }

        //implementing multi-threading for parallel requests
        //Validation applied for length of Account number 
        [HttpGet("{accno:length(10)}")]
        public async Task<List<Transaction>> Get(long accno)
        {
            var data = await _transactionService.GetAsync(accno);
            return data;
        }
    }
}
