namespace DentalClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemodels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Doctor", "WorkAgreementId", "dbo.WorkAgreement");
            DropForeignKey("dbo.Nurse", "WorkContractId", "dbo.WorkContract");
            DropIndex("dbo.Doctor", new[] { "WorkAgreementId" });
            DropIndex("dbo.Nurse", new[] { "WorkContractId" });
            AddColumn("dbo.Doctor", "WorkAgreement", c => c.Int(nullable: false));
            AddColumn("dbo.Nurse", "Salary", c => c.Double(nullable: false));
            AddColumn("dbo.Nurse", "NumberOfMontlyWorkedHours", c => c.Int(nullable: false));
            DropTable("dbo.WorkAgreement");
            DropTable("dbo.WorkContract");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.WorkContract",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumberOfMontlyWorkedHours = c.Int(nullable: false),
                        NumberOfLeaveDays = c.Int(nullable: false),
                        Salary = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WorkAgreement",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IncomePercentage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Nurse", "NumberOfMontlyWorkedHours");
            DropColumn("dbo.Nurse", "Salary");
            DropColumn("dbo.Doctor", "WorkAgreement");
            CreateIndex("dbo.Nurse", "WorkContractId");
            CreateIndex("dbo.Doctor", "WorkAgreementId");
            AddForeignKey("dbo.Nurse", "WorkContractId", "dbo.WorkContract", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Doctor", "WorkAgreementId", "dbo.WorkAgreement", "Id", cascadeDelete: true);
        }
    }
}
