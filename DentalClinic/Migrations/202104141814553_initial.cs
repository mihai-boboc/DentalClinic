namespace DentalClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartFrom = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        NurseId = c.Int(nullable: false),
                        ProcedureId = c.Int(nullable: false),
                        Observations = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Doctor", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Nurse", t => t.NurseId, cascadeDelete: true)
                .ForeignKey("dbo.Procedure", t => t.ProcedureId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.DoctorId)
                .Index(t => t.NurseId)
                .Index(t => t.ProcedureId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        CustomerSex = c.Int(nullable: false),
                        PhoneNumber = c.String(),
                        EmailAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Doctor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        EmailAddress = c.String(),
                        Speciality = c.Int(nullable: false),
                        WorkAgreementId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkAgreement", t => t.WorkAgreementId, cascadeDelete: true)
                .Index(t => t.WorkAgreementId);
            
            CreateTable(
                "dbo.WorkAgreement",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IncomePercentage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Nurse",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        EmailAddress = c.String(),
                        Speciality = c.Int(nullable: false),
                        WorkContractId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkContract", t => t.WorkContractId, cascadeDelete: true)
                .Index(t => t.WorkContractId);
            
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
                "dbo.Procedure",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Duration = c.DateTime(nullable: false),
                        Speciality = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointment", "ProcedureId", "dbo.Procedure");
            DropForeignKey("dbo.Appointment", "NurseId", "dbo.Nurse");
            DropForeignKey("dbo.Nurse", "WorkContractId", "dbo.WorkContract");
            DropForeignKey("dbo.Appointment", "DoctorId", "dbo.Doctor");
            DropForeignKey("dbo.Doctor", "WorkAgreementId", "dbo.WorkAgreement");
            DropForeignKey("dbo.Appointment", "CustomerId", "dbo.Customer");
            DropIndex("dbo.Nurse", new[] { "WorkContractId" });
            DropIndex("dbo.Doctor", new[] { "WorkAgreementId" });
            DropIndex("dbo.Appointment", new[] { "ProcedureId" });
            DropIndex("dbo.Appointment", new[] { "NurseId" });
            DropIndex("dbo.Appointment", new[] { "DoctorId" });
            DropIndex("dbo.Appointment", new[] { "CustomerId" });
            DropTable("dbo.Procedure");
            DropTable("dbo.WorkContract");
            DropTable("dbo.Nurse");
            DropTable("dbo.WorkAgreement");
            DropTable("dbo.Doctor");
            DropTable("dbo.Customer");
            DropTable("dbo.Appointment");
        }
    }
}
