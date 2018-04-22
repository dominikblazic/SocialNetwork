namespace MiniFacebook.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedPostClass : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "Text", c => c.String(nullable: false, maxLength: 450));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "Text", c => c.String());
        }
    }
}
