namespace SistemaPueblito.Web.Data
{
    using SistemaPueblito.Web.Data.Entities;
    using System.Linq;
    using System.Threading.Tasks;

    public class SeedDb
    {
        private readonly DataContext context;

        public SeedDb(DataContext context)
        {
            this.context = context;
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            if (!this.context.Houses.Any())
            {
                this.AddHouse("1");
                this.AddHouse("2");
                this.AddHouse("3");
                this.AddHouse("4");
                this.AddHouse("5");
                this.AddHouse("6");
                this.AddHouse("7");
                this.AddHouse("9");
                this.AddHouse("10");
                this.AddHouse("11");
                this.AddHouse("12");
                this.AddHouse("14");
                this.AddHouse("15");
                await this.context.SaveChangesAsync();

            }
        }

        private void AddHouse(string name)
        {
            this.context.Houses.Add(new House
            {
                Name = name,
            });
        }
    }
}
