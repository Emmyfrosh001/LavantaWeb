namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productImageEditCurrection : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ProductImage1", c => c.String(maxLength: 200));
            AlterColumn("dbo.Products", "ProductImage2", c => c.String(maxLength: 200));
            AlterColumn("dbo.Products", "ProductImage3", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ProductImage3", c => c.String(maxLength: 250));
            AlterColumn("dbo.Products", "ProductImage2", c => c.String(maxLength: 250));
            AlterColumn("dbo.Products", "ProductImage1", c => c.String(maxLength: 250));
        }
    }
}
