namespace SistemaPueblito.Web.Data
{
    using Microsoft.AspNetCore.Identity;
    using SistemaPueblito.Web.Data.Entities;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly UserManager<User> userManager;

        public SeedDb(DataContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            var user = await this.userManager.FindByEmailAsync("ssergiocr01@gmail.com");

            if (user == null)
            {
                user = new User
                {
                    FirstName = "Sergio",
                    LastName = "Serrano Vargas",
                    Email = "ssergiocr01@gmail.com",
                    UserName = "ssergiocr01@gmail.com"
                };

                var result = await this.userManager.CreateAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("No se pudo crear el usuario");
                }
            }

            if (!this.context.Houses.Any())
            {
                this.AddHouse("1",user);
                this.AddHouse("2", user);
                this.AddHouse("3", user);
                this.AddHouse("4", user);
                this.AddHouse("5", user);
                this.AddHouse("6", user);
                this.AddHouse("7", user);
                this.AddHouse("9", user);
                this.AddHouse("10", user);
                this.AddHouse("11", user);
                this.AddHouse("12", user);
                this.AddHouse("14", user);
                this.AddHouse("15", user);
                await this.context.SaveChangesAsync();

            }
        }

        private void AddHouse(string name, User user)
        {
            this.context.Houses.Add(new House
            {
                Name = name,
                User = user
            });
        }
    }
}
