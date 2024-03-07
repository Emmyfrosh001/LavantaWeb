namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserCityDistrictEdit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "UserCity", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "UserDistrict", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "UserDistrict", c => c.String(maxLength: 16));
            AlterColumn("dbo.Users", "UserCity", c => c.String(maxLength: 15));
        }
    }
}
