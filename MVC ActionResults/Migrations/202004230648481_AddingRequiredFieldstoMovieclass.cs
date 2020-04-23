namespace MVC_ActionResults.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingRequiredFieldstoMovieclass : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String());
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String());
        }
    }
}
