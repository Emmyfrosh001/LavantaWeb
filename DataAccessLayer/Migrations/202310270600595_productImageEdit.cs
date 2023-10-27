namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productImageEdit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ProductImage1", c => c.String(maxLength: 250));
            AddColumn("dbo.Products", "ProductImage2", c => c.String(maxLength: 250));
            AddColumn("dbo.Products", "ProductImage3", c => c.String(maxLength: 250));
            DropColumn("dbo.Products", "Productımage1");
            DropColumn("dbo.Products", "Productımage2");
            DropColumn("dbo.Products", "Productımage3");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Productımage3", c => c.String(maxLength: 250));
            AddColumn("dbo.Products", "Productımage2", c => c.String(maxLength: 250));
            AddColumn("dbo.Products", "Productımage1", c => c.String(maxLength: 250));
            DropColumn("dbo.Products", "ProductImage3");
            DropColumn("dbo.Products", "ProductImage2");
            DropColumn("dbo.Products", "ProductImage1");
        }
    }
}
