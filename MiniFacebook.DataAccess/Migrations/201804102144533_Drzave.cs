namespace MiniFacebook.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Drzave : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drzavas",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "DrzavaId", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "DrzavaId");
            AddForeignKey("dbo.AspNetUsers", "DrzavaId", "dbo.Drzavas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "DrzavaId", "dbo.Drzavas");
            DropIndex("dbo.AspNetUsers", new[] { "DrzavaId" });
            DropColumn("dbo.AspNetUsers", "DrzavaId");
            DropTable("dbo.Drzavas");
        }
    }
}
