namespace SistemaPueblito.Web.Controllers
{
    using Data.Entities;
    using Data.Repositories;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using SistemaPueblito.Web.Helpers;
    using System.Threading.Tasks;

    [Authorize]
    public class HousesController : Controller
    {
        private readonly IHouseRepository houseRepository;
        private readonly IUserHelper userHelper;

        public HousesController(IHouseRepository houseRepository, IUserHelper userHelper)
        {
            this.houseRepository = houseRepository;
            this.userHelper = userHelper;
        }

        // GET: Houses
        public IActionResult Index()
        {
            return View(this.houseRepository.GetAll());
        }

        // GET: Houses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var house = await this.houseRepository.GetByIdAsync(id.Value);
            if (house == null)
            {
                return NotFound();
            }

            return View(house);
        }

        // GET: Houses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Houses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(House house)
        {
            if (ModelState.IsValid)
            {                
                house.User = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                await this.houseRepository.CreateAsync(house);
                return RedirectToAction(nameof(Index));
            }
            return View(house);
        }

        // GET: Houses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var house = await this.houseRepository.GetByIdAsync(id.Value);
            if (house == null)
            {
                return NotFound();
            }
            return View(house);
        }

        // POST: Houses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(House house)
        {

            if (ModelState.IsValid)
            {
                try
                {                    
                    house.User = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                    await this.houseRepository.UpdateAsync(house);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.houseRepository.ExistAsync(house.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(house);
        }

        // GET: Houses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var house = await this.houseRepository.GetByIdAsync(id.Value);
            if (house == null)
            {
                return NotFound();
            }

            return View(house);
        }

        // POST: Houses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var house = await this.houseRepository.GetByIdAsync(id);
            await this.houseRepository.DeleteAsync(house);
            return RedirectToAction(nameof(Index));
        }


    }
}
