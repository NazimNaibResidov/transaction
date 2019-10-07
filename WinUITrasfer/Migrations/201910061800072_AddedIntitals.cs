namespace WinUITrasfer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIntitals : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountNumber = c.String(),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FormAccount = c.String(),
                        ToAccount = c.String(),
                        TrasferAmmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TrasferData = c.DateTime(nullable: false),
                        IsTrasferSuccessFul = c.Boolean(nullable: false),
                        FailedReason = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Logs");
            DropTable("dbo.Accounts");
        }
    }
}
