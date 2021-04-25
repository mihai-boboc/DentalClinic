namespace DentalClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyProcedure : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Procedure", "Duration", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Procedure", "Duration");
        }
    }
}
