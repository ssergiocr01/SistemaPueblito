namespace SistemaPueblito.Web.Data.Repositories
{
    using Entities;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IChildRepository : IGenericRepository<Child>
    {
        IQueryable GetAllWithUsers();        
    }
}
