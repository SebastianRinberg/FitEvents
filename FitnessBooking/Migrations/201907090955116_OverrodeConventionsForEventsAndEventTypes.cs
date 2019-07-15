namespace FitnessBooking.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class OverrodeConventionsForEventsAndEventTypes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "EventType_Id", "dbo.EventTypes");
            DropForeignKey("dbo.Events", "Instructor_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Events", new[] { "EventType_Id" });
            DropIndex("dbo.Events", new[] { "Instructor_Id" });
            AlterColumn("dbo.Events", "Description", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Events", "EventType_Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Events", "Instructor_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.EventTypes", "Name", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Events", "EventType_Id");
            CreateIndex("dbo.Events", "Instructor_Id");
            AddForeignKey("dbo.Events", "EventType_Id", "dbo.EventTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Events", "Instructor_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Events", "Instructor_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Events", "EventType_Id", "dbo.EventTypes");
            DropIndex("dbo.Events", new[] { "Instructor_Id" });
            DropIndex("dbo.Events", new[] { "EventType_Id" });
            AlterColumn("dbo.EventTypes", "Name", c => c.String());
            AlterColumn("dbo.Events", "Instructor_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Events", "EventType_Id", c => c.Byte());
            AlterColumn("dbo.Events", "Description", c => c.String());
            CreateIndex("dbo.Events", "Instructor_Id");
            CreateIndex("dbo.Events", "EventType_Id");
            AddForeignKey("dbo.Events", "Instructor_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Events", "EventType_Id", "dbo.EventTypes", "Id");
        }
    }
}
