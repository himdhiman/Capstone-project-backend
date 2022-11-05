using OnlineBank.API.Interfaces;
using OnlineBank.API.Models.DTOs;

namespace OnlineBank.API.Validators
{
    static class FundTransferObjectValidator
    {
        public static async Task<bool> Validate(IUserRepository usersService, FundTransferDTO newFundTransfer)
        {
            var sourceUser = await usersService.GetAsyncByAccountNumber(newFundTransfer.SourceAccountNumber);
            var destinationUser = await usersService.GetAsyncByAccountNumber(newFundTransfer.destinationAccountNumber);

            if(sourceUser != null && destinationUser != null)
            {
                float sourceAccountBalance = sourceUser.AccountBalance;
                float destinationAccountBalance = destinationUser.AccountBalance;

                if (sourceAccountBalance >= newFundTransfer.TransferAmount)
                {
                    var newSourceBalance = sourceAccountBalance - newFundTransfer.TransferAmount;
                    var newDestinationBalance = destinationAccountBalance + newFundTransfer.TransferAmount;

                    await usersService.UpdateBalance(newFundTransfer.SourceAccountNumber, (float)newSourceBalance);
                    await usersService.UpdateBalance(newFundTransfer.destinationAccountNumber, (float)newDestinationBalance);

                    return true;
                }
            }
            return false;
        }
    }
}
