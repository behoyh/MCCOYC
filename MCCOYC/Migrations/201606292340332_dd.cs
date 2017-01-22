namespace MCCOYC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.YouthRegistrations", "WaiverConfirm", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.YouthRegistrations", "WaiverConfirm", c => c.String());
        }
    }
}
