using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WinUITrasfer.Exseption;
using WinUITrasfer.Helpers;
using WinUITrasfer.Models;

namespace WinUITrasfer.Op
{
   public class Transfer
    {
        private static object _syncObject = new object();
        private bool isOperationSuccessFull = true;
        /// <summary>
        /// Exceptions:
        /// AggregateException
        /// TransactionFailedExeption
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="amount"></param>
        /// <returns></returns>

        internal bool TranserfMoney(string from,string to,decimal amount)
        {
            
          Thread thread=  new Thread(y =>
            {
                try
                {
                      lock(_syncObject)
                {
                    using (TrasferDbContext context = new TrasferDbContext())
                    {
   Account fromAccount = Tools.FromAccount(context, from);
   Account toAccount = Tools.ToAccount(context, from);
                        
   Tools.IsAccountNull(context, fromAccount, "from Account not exists");
   Tools.IsAccountNull(context, toAccount, "from Account not exists");
    if (Tools.IsAmountEnough(context, fromAccount, amount))
                        {
                            fromAccount.Balance -= amount;
                            toAccount.Balance += amount;

                               context.Logs.Add( new Log
                               {
                                   FailedReason = "Failed Reason not",
                                   FormAccount = from,
                                   ToAccount = to,
                                   TrasferAmmount = amount,
                                   IsTrasferSuccessFul = false,
                                   TrasferData = DateTime.Now


                               });
                                context.SaveChanges();
                        }
                    }
                }
                }
                catch(AggregateException ex)
                {

                }
                catch (TransactionFailedExeption ex)
                {
                    using (TrasferDbContext db=new TrasferDbContext())
                    {
                        db.Logs.Add(new Log
                        {
                            FailedReason = ex.Message,
                            FormAccount = from,
                            ToAccount = to,
                            TrasferAmmount = amount,
                            IsTrasferSuccessFul = false,
                            TrasferData = DateTime.Now


                        }) ;
                        isOperationSuccessFull = false;
                        db.SaveChanges();
                    }
                   
                }
             
                
                

            });
            thread.Start();
            thread.Join();
            return isOperationSuccessFull;
        }
        
    }
}
