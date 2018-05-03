namespace MiniFacebook.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedLike1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Likes", "ApplicationUserId", c => c.Int(nullable: false));
            DropColumn("dbo.Likes", "IsLiked");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Likes", "IsLiked", c => c.Boolean(nullable: false));
            DropColumn("dbo.Likes", "ApplicationUserId");
        }
    }
}
