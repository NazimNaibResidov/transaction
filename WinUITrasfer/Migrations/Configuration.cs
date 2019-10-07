namespace WinUITrasfer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WinUITrasfer.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WinUITrasfer.Models.TrasferDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WinUITrasfer.Models.TrasferDbContext context)
        {
            if (!context.Accounts.Any())
            {
 Account account = new Account
            {
                AccountNumber = "122-122-123",
                Balance = 8500,
                IsActive = true
            };
            Account account1 = new Account
            {
                AccountNumber = "122-122-123",
                Balance = 4500,
                IsActive = true
            };
            Account account2 = new Account
            {
                AccountNumber = "122-122-123",
                Balance = 1500,
                IsActive = false
            };
            context.Accounts.AddOrUpdate(account, account1, account2);
            }
           
        }
    }
}
