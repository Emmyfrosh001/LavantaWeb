namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userUpdateSutun : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "UserPassword", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "UserPassword", c => c.String(maxLength: 50));
        }
    }
}
