using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinUITrasfer.Exseption;
using WinUITrasfer.Models;

namespace WinUITrasfer.Helpers
{
   public class Tools
    {
        public static string IsAccountNull(TrasferDbContext context, Account account,string errorMessaje)
        {
            if (account==null)
            {
             context.Dispose();
              throw new TransactionFailedExeption(errorMessaje);
            }
            return errorMessaje;
           
        }
        public static bool IsAmountEnough(TrasferDbContext context,Account account,decimal Amount)
        {
            bool  IsResult = false;

            if (account.Balance < Amount)
            {
                IsResult = false;
                context.Dispose();
                throw new AmountIsEnoughtExspetion("Balance is Enought ");
            }
            else if (account.Balance > Amount)
            {
                IsResult = false;
                context.Dispose();
                throw new AmountIsEnoughtExspetion("Balance is Match ");
            }
            else
            {
                IsResult = true;

            }
            return IsResult;

        }
        
        public static Account FromAccount(TrasferDbContext context, string from)
        {
            return context.Accounts.Where(x => x.AccountNumber == from).FirstOrDefault();
        }
        public static Account ToAccount(TrasferDbContext context, string to)
        {
            return context.Accounts.Where(x => x.AccountNumber == to).FirstOrDefault();
        }
    }
}
