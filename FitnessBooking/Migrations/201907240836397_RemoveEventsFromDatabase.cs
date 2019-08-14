namespace FitnessBooking.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RemoveEventsFromDatabase : DbMigration
    {
        public override void Up()
        {
        }

        public override void Down()
        {
            Sql("DELETE FROM dbo.Events WHERE id IN (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11)");
        }
    }
}
