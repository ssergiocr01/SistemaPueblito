namespace SistemaPueblito.Web.Data.Repositories
{
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class ChildRepository : GenericRepository<Child>, IChildRepository
    {
        private readonly DataContext context;

        public ChildRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable GetAllWithUsers()
        {
            return this.context.Children.Include(c => c.User).OrderBy(c => c.FullName);
        }
    }
}
