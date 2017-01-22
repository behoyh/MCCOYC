namespace MCCOYC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newAtturibute : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.YouthRegistrations", "RobereProperty", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.YouthRegistrations", "RobereProperty");
        }
    }
}
