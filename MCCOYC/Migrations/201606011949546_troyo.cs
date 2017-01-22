namespace MCCOYC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class troyo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoomID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
      

        }
        
        public override void Down()
        {
            DropTable("dbo.Rooms");
        }
    }
}
