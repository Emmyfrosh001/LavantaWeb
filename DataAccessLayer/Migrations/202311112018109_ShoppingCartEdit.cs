namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShoppingCartEdit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ProductShoppingCartInsertCount", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "ProductShoppingCartDeleteCount", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "ProductBasketInsertCount");
            DropColumn("dbo.Products", "ProductBasketDeleteCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ProductBasketDeleteCount", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "ProductBasketInsertCount", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "ProductShoppingCartDeleteCount");
            DropColumn("dbo.Products", "ProductShoppingCartInsertCount");
        }
    }
}
