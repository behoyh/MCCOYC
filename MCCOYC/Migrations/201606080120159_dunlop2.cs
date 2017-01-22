namespace MCCOYC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dunlop2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "UserID1", c => c.String());
            AddColumn("dbo.Rooms", "UserID2", c => c.String());
            DropColumn("dbo.Rooms", "YouthID1");
            DropColumn("dbo.Rooms", "YouthID2");
            DropColumn("dbo.YouthRegistrations", "YouthID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.YouthRegistrations", "YouthID", c => c.String());
            AddColumn("dbo.Rooms", "YouthID2", c => c.String());
            AddColumn("dbo.Rooms", "YouthID1", c => c.String());
            DropColumn("dbo.Rooms", "UserID2");
            DropColumn("dbo.Rooms", "UserID1");
        }
    }
}
