namespace SistemaPueblito.Web.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;

    public class Repository : IRepository
    {
        private readonly DataContext context;

        public Repository(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<House> GetHouses()
        {
            return this.context.Houses.OrderBy(p => p.Name);
        }

        public House GetHouse(int id)
        {
            return this.context.Houses.Find(id);
        }

        public void AddHouse(House House)
        {
            this.context.Houses.Add(House);
        }

        public void UpdateHouse(House House)
        {
            this.context.Update(House);
        }

        public void RemoveHouse(House House)
        {
            this.context.Houses.Remove(House);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await this.context.SaveChangesAsync() > 0;
        }

        public bool HouseExists(int id)
        {
            return this.context.Houses.Any(p => p.Id == id);
        }
    }
}
