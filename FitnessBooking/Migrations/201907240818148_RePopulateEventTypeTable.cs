namespace FitnessBooking.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RePopulateEventTypeTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO EventTypes (Id, Name) VALUES (5, 'Spinning-Intermediate')");
            Sql("INSERT INTO EventTypes (Id, Name) VALUES (6, 'Spinning-Advanced')");
            Sql("INSERT INTO EventTypes (Id, Name) VALUES (7, 'Bodytoning ')");
            Sql("INSERT INTO EventTypes (Id, Name) VALUES (8, 'Zumba')");
            Sql("INSERT INTO EventTypes (Id, Name) VALUES (9, 'Hiit')");
            Sql("INSERT INTO EventTypes (Id, Name) VALUES (10, 'Crossfit')");
        }

        public override void Down()
        {
            Sql("DELETE FROM EventTypes WHERE id IN (5, 6, 7, 8, 9, 10)");
        }
    }
}
