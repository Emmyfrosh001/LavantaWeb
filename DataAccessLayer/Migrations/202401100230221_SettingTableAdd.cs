namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SettingTableAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        SettingID = c.Int(nullable: false, identity: true),
                        Announcement = c.String(maxLength: 250),
                        CargoPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SettingID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Settings");
        }
    }
}
