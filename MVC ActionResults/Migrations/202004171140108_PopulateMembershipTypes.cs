namespace MVC_ActionResults.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into MembershipTypes(Id, Name,SignUpFee,DurationInMonths,DiscountRate) values(1,'PayAsYouGo',0,0,0)" );
            Sql("Insert into MembershipTypes(Id, Name,SignUpFee,DurationInMonths,DiscountRate) values(2,'Monthly',30,1,10)");
            Sql("Insert into MembershipTypes(Id, Name,SignUpFee,DurationInMonths,DiscountRate) values(3,'Quartely',90,3,15)");
            Sql("Insert into MembershipTypes(Id, Name,SignUpFee,DurationInMonths,DiscountRate) values(4,'Yearly',300,12,20)");
        }
        
        public override void Down()
        {
        }
    }
}
