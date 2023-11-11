namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShoppingCartAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        CartID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        ProductPiece = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CartID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCarts", "UserID", "dbo.Users");
            DropForeignKey("dbo.ShoppingCarts", "ProductID", "dbo.Products");
            DropIndex("dbo.ShoppingCarts", new[] { "ProductID" });
            DropIndex("dbo.ShoppingCarts", new[] { "UserID" });
            DropTable("dbo.ShoppingCarts");
        }
    }
}
