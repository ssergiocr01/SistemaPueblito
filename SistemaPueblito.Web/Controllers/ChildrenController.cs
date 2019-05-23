namespace SistemaPueblito.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using SistemaPueblito.Web.Data.Entities;
    using SistemaPueblito.Web.Data.Repositories;
    using SistemaPueblito.Web.Helpers;
    using SistemaPueblito.Web.Models;
    using System;
    using System.IO;
    using System.Threading.Tasks;

    [Authorize]
    public class ChildrenController : Controller
    {
        private readonly IChildRepository childRepository;        
        private readonly IUserHelper userHelper;

        public ChildrenController(IChildRepository childRepository,            
            IUserHelper userHelper)
        {
            this.childRepository = childRepository;
            
            this.userHelper = userHelper;
        }        

        public IActionResult Index()
        {
            return View(this.childRepository.GetAll());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var child = await this.childRepository.GetByIdAsync(id.Value);
            if (child == null)
            {
                return NotFound();
            }

            return View(child);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ChildViewModel view)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;

                if (view.ImageFile != null && view.ImageFile.Length > 0)
                {
                    var guid = Guid.NewGuid().ToString();
                    var file = $"{guid}.jpg";

                    path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\Children", file);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await view.ImageFile.CopyToAsync(stream);
                    }

                    path = $"~/images/Children/{file}";
                }

                view.User = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                var child = this.ToChild(view, path);
                await this.childRepository.CreateAsync(child);
                return RedirectToAction(nameof(Index));
            }

            return View(view);
        }

        private Child ToChild(ChildViewModel view, string path)
        {
            return new Child
            {
                Id = view.Id,
                ImageUrl = path,
                Age = view.Age,
                BirthDate = view.BirthDate,
                FirstName = view.FirstName,
                LastName = view.LastName,
                User = view.User
            };
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var child = await this.childRepository.GetByIdAsync(id.Value);
            if (child == null)
            {
                return NotFound();
            }

            var view = this.ToChildViewModel(child);
            return View(view);
        }

        private ChildViewModel ToChildViewModel(Child child)
        {
            return new ChildViewModel
            {
                Id = child.Id,
                ImageUrl = child.ImageUrl,
                Age = child.Age,
                BirthDate = child.BirthDate,
                FirstName = child.FirstName,
                LastName = child.LastName,
                User = child.User,
            };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ChildViewModel view)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var path = view.ImageUrl;

                    if (view.ImageFile != null && view.ImageFile.Length > 0)
                    {
                        var guid = Guid.NewGuid().ToString();
                        var file = $"{guid}.jpg";

                        path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\Children", file);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await view.ImageFile.CopyToAsync(stream);
                        }

                        path = $"~/images/Children/{file}";
                    }

                    view.User = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                    var child = this.ToChild(view, path);
                    await this.childRepository.UpdateAsync(child);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.childRepository.ExistAsync(view.Id))
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

            return View(view);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var child = await this.childRepository.GetByIdAsync(id.Value);
            if (child == null)
            {
                return NotFound();
            }

            return View(child);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var child = await this.childRepository.GetByIdAsync(id);
            await this.childRepository.DeleteAsync(child);
            return RedirectToAction(nameof(Index));
        }
    }
}
