namespace DentalClinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableFieldsAppointment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointment", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Appointment", "DoctorId", "dbo.Doctor");
            DropForeignKey("dbo.Appointment", "NurseId", "dbo.Nurse");
            DropForeignKey("dbo.Appointment", "ProcedureId", "dbo.Procedure");
            DropIndex("dbo.Appointment", new[] { "CustomerId" });
            DropIndex("dbo.Appointment", new[] { "DoctorId" });
            DropIndex("dbo.Appointment", new[] { "NurseId" });
            DropIndex("dbo.Appointment", new[] { "ProcedureId" });
            AlterColumn("dbo.Appointment", "CustomerId", c => c.Int());
            AlterColumn("dbo.Appointment", "DoctorId", c => c.Int());
            AlterColumn("dbo.Appointment", "NurseId", c => c.Int());
            AlterColumn("dbo.Appointment", "ProcedureId", c => c.Int());
            CreateIndex("dbo.Appointment", "CustomerId");
            CreateIndex("dbo.Appointment", "DoctorId");
            CreateIndex("dbo.Appointment", "NurseId");
            CreateIndex("dbo.Appointment", "ProcedureId");
            AddForeignKey("dbo.Appointment", "CustomerId", "dbo.Customer", "Id");
            AddForeignKey("dbo.Appointment", "DoctorId", "dbo.Doctor", "Id");
            AddForeignKey("dbo.Appointment", "NurseId", "dbo.Nurse", "Id");
            AddForeignKey("dbo.Appointment", "ProcedureId", "dbo.Procedure", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointment", "ProcedureId", "dbo.Procedure");
            DropForeignKey("dbo.Appointment", "NurseId", "dbo.Nurse");
            DropForeignKey("dbo.Appointment", "DoctorId", "dbo.Doctor");
            DropForeignKey("dbo.Appointment", "CustomerId", "dbo.Customer");
            DropIndex("dbo.Appointment", new[] { "ProcedureId" });
            DropIndex("dbo.Appointment", new[] { "NurseId" });
            DropIndex("dbo.Appointment", new[] { "DoctorId" });
            DropIndex("dbo.Appointment", new[] { "CustomerId" });
            AlterColumn("dbo.Appointment", "ProcedureId", c => c.Int(nullable: false));
            AlterColumn("dbo.Appointment", "NurseId", c => c.Int(nullable: false));
            AlterColumn("dbo.Appointment", "DoctorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Appointment", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Appointment", "ProcedureId");
            CreateIndex("dbo.Appointment", "NurseId");
            CreateIndex("dbo.Appointment", "DoctorId");
            CreateIndex("dbo.Appointment", "CustomerId");
            AddForeignKey("dbo.Appointment", "ProcedureId", "dbo.Procedure", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Appointment", "NurseId", "dbo.Nurse", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Appointment", "DoctorId", "dbo.Doctor", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Appointment", "CustomerId", "dbo.Customer", "Id", cascadeDelete: true);
        }
    }
}
