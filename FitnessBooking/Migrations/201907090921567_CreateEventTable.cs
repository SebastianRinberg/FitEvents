namespace FitnessBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEventTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Description = c.String(),
                        EventType_Id = c.Byte(),
                        Instructor_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventTypes", t => t.EventType_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Instructor_Id)
                .Index(t => t.EventType_Id)
                .Index(t => t.Instructor_Id);
            
            CreateTable(
                "dbo.EventTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "Instructor_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Events", "EventType_Id", "dbo.EventTypes");
            DropIndex("dbo.Events", new[] { "Instructor_Id" });
            DropIndex("dbo.Events", new[] { "EventType_Id" });
            DropTable("dbo.EventTypes");
            DropTable("dbo.Events");
        }
    }
}
