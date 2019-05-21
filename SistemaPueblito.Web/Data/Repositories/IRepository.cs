using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaPueblito.Web.Data.Entities;

namespace SistemaPueblito.Web.Data.Repositories
{
    public interface IRepository
    {
        void AddHouse(House House);
        House GetHouse(int id);
        IEnumerable<House> GetHouses();
        bool HouseExists(int id);
        void RemoveHouse(House House);
        Task<bool> SaveAllAsync();
        void UpdateHouse(House House);
    }
}