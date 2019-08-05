namespace SmallCRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DescSilindi : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Companies", "Location", c => c.String(maxLength: 100));
            DropColumn("dbo.Companies", "InvoiceDescription");
            DropColumn("dbo.Companies", "DeliveryDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Companies", "DeliveryDescription", c => c.String(maxLength: 4000));
            AddColumn("dbo.Companies", "InvoiceDescription", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Companies", "Location", c => c.String());
        }
    }
}
