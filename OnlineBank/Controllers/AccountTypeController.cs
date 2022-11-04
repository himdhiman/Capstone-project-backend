using Microsoft.AspNetCore.Mvc;
using OnlineBank.API.Interfaces;
using OnlineBank.API.Models;

namespace OnlineBank.API.Controllers
{
    [Route("api/accountType/[controller]")]
    [ApiController]
    public class AccountTypeController : ControllerBase
    {
        private readonly IRepository<Account> _accountsService;

        public AccountTypeController(IDataService dataService)
        {
            _accountsService = dataService.AccountsDataObject;
        }

        [HttpGet]
        public async Task<List<Account>> Get() => await _accountsService.GetAsync();
    }
}
