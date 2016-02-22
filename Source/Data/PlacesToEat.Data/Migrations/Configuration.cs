namespace PlacesToEat.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Models.Users;

    public sealed class Configuration : DbMigrationsConfiguration<PlacesToEatDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PlacesToEatDbContext context)
        {
            var userManager = new UserManager<User>(new UserStore<User>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Regular" });
                roleManager.Create(new IdentityRole { Name = "Restaurant" });
                roleManager.Create(new IdentityRole { Name = "Administrator" });
            }

            if (!context.Categories.Any())
            {
                var category = new Category
                {
                    Name = "All"
                };

                context.Categories.Add(category);

                category = new Category
                {
                    Name = "Fast Food"
                };

                context.Categories.Add(category);

                category = new Category
                {
                    Name = "Casual"
                };

                context.Categories.Add(category);

                category = new Category
                {
                    Name = "Steak House"
                };

                context.Categories.Add(category);

                category = new Category
                {
                    Name = "Bar"
                };

                context.Categories.Add(category);

                category = new Category
                {
                    Name = "Chinese Food"
                };

                context.Categories.Add(category);

                category = new Category
                {
                    Name = "Italian Food"
                };

                context.Categories.Add(category);

                context.SaveChanges();
            }
        }
    }
}
