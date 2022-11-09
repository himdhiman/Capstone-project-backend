using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineBank.API.Interfaces;
using OnlineBank.API.Models;
using OnlineBank.API.Models.DTOs;

namespace OnlineBank.API.Controllers
{
    [Route("api/accountType/[controller]")]
    [ApiController]
    public class AccountTypeController : ControllerBase
    {
        private readonly IRepository<Account> _accountsService;
        private readonly IMapper _mapper;

        public AccountTypeController(IDataService dataService, IMapper mapper)
        {
            _accountsService = dataService.AccountsDataObject;
            _mapper = mapper;
        }

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
