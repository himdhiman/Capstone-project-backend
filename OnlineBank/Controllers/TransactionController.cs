using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineBank.API.Interfaces;
using OnlineBank.API.Models.DTOs;
using OnlineBank.API.Models;
using OnlineBank.API.Validators;

namespace OnlineBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _transactionService;
        private readonly IMapper _mapper;

        public TransactionController(IDataService dataservice, IMapper mapper)
        {
            _mapper = mapper;
            _transactionService = dataservice.TransactionDataObject;
        }

        [HttpGet("{accno:length(10)}")]
        public async Task<List<Transaction>> Get(long accno)
        {
            var data = await _transactionService.GetAsync(accno);
            if(data.Count > 5)
            {
                return data.GetRange(data.Count - 6, data.Count);
            }
            return data;
        }
    }
}
