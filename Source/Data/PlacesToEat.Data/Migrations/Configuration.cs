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

            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 4,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

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

                category = new Category
                {
                    Name = "Pizza"
                };

                context.Categories.Add(category);

                context.SaveChanges();
            }

            var initialUser = userManager.Users.FirstOrDefault(x => x.UserName == "admin");

            if (initialUser == null)
            {
                var user = new User
                {
                    UserName = "admin"
                };

                var result = userManager.Create(user, "admin");

                userManager.AddToRole(user.Id, "Administrator");

                user = new RegularUser
                {
                    FirstName = "User",
                    LastName = "Testov",
                    UserName = "user"
                };

                result = userManager.Create(user, "user");

                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Regular");
                }

                user = new RegularUser
                {
                    FirstName = "Pesho",
                    LastName = "Peshov",
                    UserName = "pesho"
                };

                result = userManager.Create(user, "pesho");

                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Regular");
                }

                var restaurant = new RestaurantUser
                {
                    Name = @"Happy ""Александър Малинов""",
                    UserName = "happy_almalinov",
                    Address = @"бул. ""Александър Малинов"" 37, 1729 София",
                    Email = "happy@happy.bg",
                    PhoneNumber = "088 818 1072",
                    Latitude = 42.6480622000956,
                    Longitude = 23.3790537714958,
                    CategoryId = 1
                };

                result = userManager.Create(restaurant, "123456");

                if (result.Succeeded)
                {
                    userManager.AddToRole(restaurant.Id, "Restaurant");
                }

                restaurant = new RestaurantUser
                {
                    Name = @"McDonalds ""Александър Малинов""",
                    UserName = "mcdonalds_almalinov",
                    Address = @"Бул. Ал. Малинов, Срещу Нова Деница, София",
                    Email = "mcdonalds@gmail.com",
                    PhoneNumber = "088 400 0310",
                    Latitude = 42.6472434650249,
                    Longitude = 23.3757828176022,
                    CategoryId = 2
                };

                result = userManager.Create(restaurant, "123456");

                if (result.Succeeded)
                {
                    userManager.AddToRole(restaurant.Id, "Restaurant");
                }

                restaurant = new RestaurantUser
                {
                    Name = @"Хепи голдън (Син Жон ООД)",
                    UserName = "happy_golden",
                    Address = @"София, бул. Ал.Малинов",
                    Email = "happy.golden@gmail.com",
                    PhoneNumber = "02 975 3688",
                    Latitude = 42.6512995505691,
                    Longitude = 23.3781887590885,
                    CategoryId = 1
                };

                result = userManager.Create(restaurant, "123456");

                if (result.Succeeded)
                {
                    userManager.AddToRole(restaurant.Id, "Restaurant");
                }

                restaurant = new RestaurantUser
                {
                    Name = @"ПИЦИ ФРИЦИ",
                    UserName = "pici_frici",
                    Address = @"жк Младост-1а 510,1729 София,България",
                    Email = "pici.frici@gmail.com",
                    PhoneNumber = "+359 2 974 3058",
                    Latitude = 42.6488631690378,
                    Longitude = 23.3802500367165,
                    CategoryId = 8
                };

                result = userManager.Create(restaurant, "123456");

                if (result.Succeeded)
                {
                    userManager.AddToRole(restaurant.Id, "Restaurant");
                }

                context.SaveChanges();
            }
        }
    }
}
