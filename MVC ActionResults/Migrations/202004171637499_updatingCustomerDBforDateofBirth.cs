namespace MVC_ActionResults.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingCustomerDBforDateofBirth : DbMigration
    {
        public override void Up()
        {
            Sql("Update Customers set Birthdate=31-05-1994 where id=1");
            Sql("Update Customers set Birthdate=30-10-2016 where id=2");
            Sql("Update Customers set Birthdate=30-10-2016 where id=3");
        }
        
        public override void Down()
        {
        }
    }
}
