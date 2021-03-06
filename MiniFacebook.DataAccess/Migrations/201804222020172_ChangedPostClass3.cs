namespace MiniFacebook.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedPostClass3 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Posts");
            AlterColumn("dbo.Posts", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Posts", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Posts");
            AlterColumn("dbo.Posts", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Posts", "Id");
        }
    }
}
