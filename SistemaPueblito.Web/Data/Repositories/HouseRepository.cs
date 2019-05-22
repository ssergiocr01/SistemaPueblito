namespace SistemaPueblito.Web.Data.Repositories
{
    using Entities;

    public class HouseRepository : GenericRepository<House>, IHouseRepository
    {
        public HouseRepository(DataContext context) : base(context)
        {
        }
    }
}
