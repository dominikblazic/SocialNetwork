namespace MiniFacebook.DataAccess.Migrations
{
    using MiniFacebook.Domena.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MiniFacebook.DataAccess.Infrastructure.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MiniFacebook.DataAccess.Infrastructure.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Drzave.AddOrUpdate(x => x.Id,
                new Drzava() { Id = "HR", Naziv = "Hrvatska"},
                new Drzava() { Id = "GB", Naziv = "Velika Britanija"},
                new Drzava() { Id = "RS", Naziv = "Republika Srbija"},
                new Drzava() { Id = "SLO", Naziv = "Slovenija"},
                new Drzava() { Id = "BiH", Naziv = "Bosna i Hercegovina"}
                );
            
        }
    }
}
