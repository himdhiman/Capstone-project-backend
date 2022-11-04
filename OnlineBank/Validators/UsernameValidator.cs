using OnlineBank.API.Interfaces;
using OnlineBank.API.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineBank.API.Validators
{
    public class UsernameValidator : ValidationAttribute
    {
        private readonly IUserRepository _usersService;
        public UsernameValidator(IDataService dataService)
        {
            _usersService = dataService.UsersDataObject;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string username = (string)value;
            var data = _usersService.GetAsyncByUsername(username);
            if(data != null)
            {
                return new ValidationResult("UserName already Taken!");
            }
            return ValidationResult.Success;
        }
    }
}
