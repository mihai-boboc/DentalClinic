namespace DentalClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemodels2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctor", "WorkAgreementPercentage", c => c.Int(nullable: false));
            DropColumn("dbo.Doctor", "WorkAgreementId");
            DropColumn("dbo.Doctor", "WorkAgreement");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Doctor", "WorkAgreement", c => c.Int(nullable: false));
            AddColumn("dbo.Doctor", "WorkAgreementId", c => c.Int(nullable: false));
            DropColumn("dbo.Doctor", "WorkAgreementPercentage");
        }
    }
}
