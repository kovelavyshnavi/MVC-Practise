namespace MVCEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAddNumberAvaialbleToMovie : DbMigration
    {
        public override void Up()
        {

            Sql("Update Movies Set NumberAvailable=NumberInStock");

        }

        public override void Down()
        {
        }
    }
}
