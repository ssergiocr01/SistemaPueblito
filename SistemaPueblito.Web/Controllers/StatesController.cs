namespace SistemaPueblito.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using SistemaPueblito.Web.Data.Entities;
    using SistemaPueblito.Web.Data.Repositories;
    using SistemaPueblito.Web.Helpers;
    using System.Threading.Tasks;

    public class StatesController : Controller
    {
        private readonly IStateRepository stateRepository;
        private readonly IUserHelper userHelper;

        public StatesController(IStateRepository stateRepository, IUserHelper userHelper)
        {
            this.stateRepository = stateRepository;
            this.userHelper = userHelper;
        }

        public IActionResult Index()
        {
            return this.View(stateRepository.GetAll());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var state = await this.stateRepository.GetByIdAsync(id.Value);
            if (id == null)
            {
                return NotFound();
            }

            return View(state);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(State state)
        {
            if (this.ModelState.IsValid)
            {
                state.User = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                await this.stateRepository.CreateAsync(state);
                return RedirectToAction(nameof(Index));
            }

            return View(state);
        }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(State state)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    state.User = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
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
