namespace SistemaPueblito.Web.Data.Repositories
{
    using Entities;

    public class StateRepository : GenericRepository<State>, IStateRepository
    {
        private readonly DataContext context;

        public StateRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
    }
}
