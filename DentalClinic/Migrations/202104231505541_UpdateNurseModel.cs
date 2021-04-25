namespace DentalClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNurseModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Nurse", "Name", c => c.String());
            DropColumn("dbo.Nurse", "FirstName");
            DropColumn("dbo.Nurse", "LastName");
            DropColumn("dbo.Nurse", "WorkContractId");
            DropColumn("dbo.Nurse", "NumberOfMontlyWorkedHours");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Nurse", "NumberOfMontlyWorkedHours", c => c.Int(nullable: false));
            AddColumn("dbo.Nurse", "WorkContractId", c => c.Int(nullable: false));
            AddColumn("dbo.Nurse", "LastName", c => c.String());
            AddColumn("dbo.Nurse", "FirstName", c => c.String());
            DropColumn("dbo.Nurse", "Name");
        }
    }
}
