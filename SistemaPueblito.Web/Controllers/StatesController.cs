namespace SistemaPueblito.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using SistemaPueblito.Web.Data.Entities;
    using SistemaPueblito.Web.Data.Repositories;
    using System.Threading.Tasks;

    public class StatesController : Controller
    {
        private readonly IStateRepository stateRepository;

        public StatesController(IStateRepository stateRepository)
        {
            this.stateRepository = stateRepository;
        }

        // GET: States
        public IActionResult Index()
        {
            return View(this.stateRepository.GetAll());
        }

        // GET: States/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var state = await this.stateRepository.GetByIdAsync(id.Value);
            if (state == null)
            {
                return NotFound();
            }

            return View(state);
        }

        // GET: States/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: States/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(State state)
        {
            if (ModelState.IsValid)
            {
                await this.stateRepository.CreateAsync(state);
                return RedirectToAction(nameof(Index));
            }
            return View(state);
        }

        // GET: States/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var state = await this.stateRepository.GetByIdAsync(id.Value);
            if (state == null)
            {
                return NotFound();
            }
            return View(state);
        }

        // POST: States/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(State state)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    await this.stateRepository.UpdateAsync(state);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.stateRepository.ExistAsync(state.Id))
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
            return View(state);
        }

        // GET: States/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var state = await this.stateRepository.GetByIdAsync(id.Value);
            if (state == null)
            {
                return NotFound();
            }

            return View(state);
        }

        // POST: States/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var state = await this.stateRepository.GetByIdAsync(id);
            await this.stateRepository.DeleteAsync(state);
            return RedirectToAction(nameof(Index));
        }

    }
}
