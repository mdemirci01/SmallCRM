namespace SmallCRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompanyLocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "CompanyLocation", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Companies", "CompanyLocation");
        }
    }
}
