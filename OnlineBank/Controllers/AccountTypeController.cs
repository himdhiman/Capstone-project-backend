using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineBank.API.Interfaces;
using OnlineBank.API.Models;
using OnlineBank.API.Models.DTOs;
//Controller for Account Type, integrated with the API
namespace OnlineBank.API.Controllers
{
    [Route("api/accountType/[controller]")]
    [ApiController]
    public class AccountTypeController : ControllerBase
    {
        //Objects of respective interfaces
        private readonly IRepository<Account> _accountsService;
        private readonly IMapper _mapper;

        //mapping objects using AutoMapper Service in C#
        public AccountTypeController(IDataService dataService, IMapper mapper)
        {
            _accountsService = dataService.AccountsDataObject;
            _mapper = mapper;
        }

        //implementing multi-threading for parallel requests
        [HttpGet]
        public async Task<List<Account>> Get() => await _accountsService.GetAsync();

        [HttpPost]
        public async Task<IActionResult> Post(AccountDTO newAccount)
        {
            Account AccObject = _mapper.Map<Account>(newAccount);
            await _accountsService.CreateAsync(AccObject);
            return Ok("Object created Successfully");
        }
    }
}
