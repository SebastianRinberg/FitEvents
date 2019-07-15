namespace FitnessBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyPropertiesToEvent : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Events", name: "EventType_Id", newName: "EventTypeId");
            RenameColumn(table: "dbo.Events", name: "Instructor_Id", newName: "InstructorId");
            RenameIndex(table: "dbo.Events", name: "IX_Instructor_Id", newName: "IX_InstructorId");
            RenameIndex(table: "dbo.Events", name: "IX_EventType_Id", newName: "IX_EventTypeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Events", name: "IX_EventTypeId", newName: "IX_EventType_Id");
            RenameIndex(table: "dbo.Events", name: "IX_InstructorId", newName: "IX_Instructor_Id");
            RenameColumn(table: "dbo.Events", name: "InstructorId", newName: "Instructor_Id");
            RenameColumn(table: "dbo.Events", name: "EventTypeId", newName: "EventType_Id");
        }
    }
}
