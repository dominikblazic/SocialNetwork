namespace MiniFacebook.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NickAppUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Nickname", c => c.String(nullable: false, maxLength: 450));
            CreateIndex("dbo.AspNetUsers", "Nickname", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.AspNetUsers", new[] { "Nickname" });
            DropColumn("dbo.AspNetUsers", "Nickname");
        }
    }
}
