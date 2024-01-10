namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdminAdminRoleEdit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "AdminRole", c => c.String(maxLength: 5));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "AdminRole", c => c.String(maxLength: 1));
        }
    }
}
