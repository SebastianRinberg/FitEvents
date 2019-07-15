namespace FitnessBooking.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateEventTypeTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO EventTypes (Id, Name) VALUES (1, 'Yoga')");
            Sql("INSERT INTO EventTypes (Id, Name) VALUES (2, 'Boxing')");
            Sql("INSERT INTO EventTypes (Id, Name) VALUES (3, 'Trx')");
            Sql("INSERT INTO EventTypes (Id, Name) VALUES (4, 'Spinning')");
        }

        public override void Down()
        {
            Sql("DELETE FROM EventTypes WHERE Id IN (1,2,3,4)");
        }
    }
}
