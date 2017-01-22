namespace MCCOYC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class troyo2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "UserID1", c => c.String());
            AddColumn("dbo.Rooms", "UserID2", c => c.String());
            DropColumn("dbo.Rooms", "RoomID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "RoomID", c => c.Int(nullable: false));
            DropColumn("dbo.Rooms", "UserID2");
            DropColumn("dbo.Rooms", "UserID1");
        }
    }
}
