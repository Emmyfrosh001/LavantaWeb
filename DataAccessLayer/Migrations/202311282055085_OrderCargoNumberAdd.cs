namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderCargoNumberAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderCargoNumber", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "OrderCargoNumber");
        }
    }
}
