namespace CabBook.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialstate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RideDetails", "ToEmail", c => c.String());
            AddColumn("dbo.RideDetails", "RiderEmail", c => c.String());
            AddColumn("dbo.RideDetails", "RiderName", c => c.String());
            AddColumn("dbo.RideDetails", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RideDetails", "PhoneNumber");
            DropColumn("dbo.RideDetails", "RiderName");
            DropColumn("dbo.RideDetails", "RiderEmail");
            DropColumn("dbo.RideDetails", "ToEmail");
        }
    }
}
