namespace MiniFacebook.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Something1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Likes", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Likes", "Post_Id", "dbo.Posts");
            DropIndex("dbo.Likes", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Likes", new[] { "Post_Id" });
            DropTable("dbo.Likes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.Int(nullable: false),
                        LikeTime = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        Post_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Likes", "Post_Id");
            CreateIndex("dbo.Likes", "ApplicationUser_Id");
            AddForeignKey("dbo.Likes", "Post_Id", "dbo.Posts", "Id");
            AddForeignKey("dbo.Likes", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
