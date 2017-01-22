namespace MCCOYC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dunlop : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.YouthRegistrations", "UserID", c => c.String());
            DropColumn("dbo.YouthRegistrations", "ParentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.YouthRegistrations", "ParentID", c => c.String());
            DropColumn("dbo.YouthRegistrations", "UserID");
        }
    }
}
