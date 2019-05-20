namespace SistemaPueblito.Web.Data
{
    using Microsoft.EntityFrameworkCore;
    using Entities;

    public class DataContext : DbContext
    {
        public DbSet<House> Houses { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
