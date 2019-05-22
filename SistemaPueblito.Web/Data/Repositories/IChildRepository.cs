namespace SistemaPueblito.Web.Data.Repositories
{
    using Entities;
    using System.Linq;

    public interface IChildRepository : IGenericRepository<Child>
    {
        IQueryable GetAllWithUsers();
    }
}
