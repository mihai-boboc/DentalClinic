namespace DentalClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctor", "Name", c => c.String());
            DropColumn("dbo.Doctor", "FirstName");
            DropColumn("dbo.Doctor", "LastName");
            DropColumn("dbo.Procedure", "Description");
            DropColumn("dbo.Procedure", "Duration");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Procedure", "Duration", c => c.DateTime(nullable: false));
            AddColumn("dbo.Procedure", "Description", c => c.String());
            AddColumn("dbo.Doctor", "LastName", c => c.String());
            AddColumn("dbo.Doctor", "FirstName", c => c.String());
            DropColumn("dbo.Doctor", "Name");
        }
    }
}
