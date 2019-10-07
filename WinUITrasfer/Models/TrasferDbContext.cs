using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUITrasfer.Models
{
  public  class TrasferDbContext:DbContext
    {
        public TrasferDbContext():base("mains")
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}
