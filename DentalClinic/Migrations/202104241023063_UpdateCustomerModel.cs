namespace DentalClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCustomerModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "DayOfBirth", c => c.DateTime(nullable: false));
            DropColumn("dbo.Customer", "Age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customer", "Age", c => c.Int(nullable: false));
            DropColumn("dbo.Customer", "DayOfBirth");
        }
    }
}
