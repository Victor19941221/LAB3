using Lab3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab3.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private  readonly RoleManager <IdentityRole> _roleManager;
        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task <IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                ModelState.AddModelError("Name", "Role name is required");
                var roles = await _roleManager.Roles.ToListAsync();
                return View(roles);
            }

            var roleExists = await _roleManager.RoleExistsAsync(name);
            if (roleExists)
            {
                ModelState.AddModelError("Name", "Role already exists");
                var roles = await _roleManager.Roles.ToListAsync();
                return View(roles);
            }

            await _roleManager.CreateAsync(new IdentityRole { Name = name.Trim() });
            return RedirectToAction("Index");
        }
        // Update (Edit role)
        public async Task<IActionResult> Edit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            var model = new RoleFormModel { Name = role.Name };
            return PartialView("_roleEditPartialView", model); // Create a partial for editing
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, RoleFormModel model)
        {
            if (ModelState.IsValid)
            {
                var role = await _roleManager.FindByIdAsync(id);
                if (role != null)
                {
                    role.Name = model.Name;
                    await _roleManager.UpdateAsync(role);
                    return RedirectToAction("Index");
                }
            }
            return View("Index", _roleManager.Roles.ToList());
        }

        // Delete (Remove role)
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                await _roleManager.DeleteAsync(role);
            }
            return RedirectToAction("Index");
        }
    }
}
