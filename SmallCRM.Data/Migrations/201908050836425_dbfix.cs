namespace SmallCRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbfix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Leads", "Website", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Leads", "Website", c => c.String());
        }
    }
}
