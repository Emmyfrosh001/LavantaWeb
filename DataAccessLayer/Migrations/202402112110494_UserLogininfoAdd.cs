namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserLogininfoAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "LoginInfo", c => c.String(maxLength: 33));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "LoginInfo");
        }
    }
}
