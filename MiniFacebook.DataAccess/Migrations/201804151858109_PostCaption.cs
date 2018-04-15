namespace MiniFacebook.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostCaption : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Caption", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Caption");
        }
    }
}
