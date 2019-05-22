namespace SistemaPueblito.Web.Data.Repositories
{
    using Entities;

    public class StateRepository : GenericRepository<State>, IStateRepository
    {
        public StateRepository(DataContext context) : base(context)
        {
        }
    }
}
