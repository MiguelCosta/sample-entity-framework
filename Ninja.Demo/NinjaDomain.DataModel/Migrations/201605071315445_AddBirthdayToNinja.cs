namespace NinjaDomain.DataModel.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddBirthdayToNinja : DbMigration
    {
        public override void Down()
        {
            DropColumn("dbo.Ninjas", "DayOfBirth");
        }

        public override void Up()
        {
            AddColumn("dbo.Ninjas", "DayOfBirth", c => c.DateTime(nullable: false));
        }
    }
}
