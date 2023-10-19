namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductInsertImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Productımage1", c => c.String(maxLength: 250));
            AddColumn("dbo.Products", "Productımage2", c => c.String(maxLength: 250));
            AddColumn("dbo.Products", "Productımage3", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Productımage3");
            DropColumn("dbo.Products", "Productımage2");
            DropColumn("dbo.Products", "Productımage1");
        }
    }
}
