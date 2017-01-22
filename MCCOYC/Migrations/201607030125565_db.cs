namespace MCCOYC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.YouthRegistrations", "EmergencyName", c => c.String());
            AddColumn("dbo.YouthRegistrations", "EmergencyRelationship", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.YouthRegistrations", "EmergencyRelationship");
            DropColumn("dbo.YouthRegistrations", "EmergencyName");
        }
    }
}
