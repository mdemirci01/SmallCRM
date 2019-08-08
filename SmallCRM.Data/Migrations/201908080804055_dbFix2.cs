namespace SmallCRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbFix2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Leads", "Company_Id", "dbo.Companies");
            DropIndex("dbo.Leads", new[] { "Company_Id" });
            DropColumn("dbo.Leads", "Company_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Leads", "Company_Id", c => c.Guid());
            CreateIndex("dbo.Leads", "Company_Id");
            AddForeignKey("dbo.Leads", "Company_Id", "dbo.Companies", "Id");
        }
    }
}
