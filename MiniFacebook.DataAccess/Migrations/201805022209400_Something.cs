namespace MiniFacebook.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Something : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Likes", "IsLiked", c => c.Boolean(nullable: false));
            AddColumn("dbo.Posts", "NrOfLikes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "NrOfLikes");
            DropColumn("dbo.Likes", "IsLiked");
        }
    }
}
