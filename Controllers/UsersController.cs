using Lab3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab3.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public UsersController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            // Get the users first
            var users = await _userManager.Users.ToListAsync();

            // Prepare the view model list
            var userViewModels = new List<UserViewModel>();

            // Loop through each user and retrieve their roles one by one
            foreach (var user in users)
            {
                var userRoles = await _userManager.GetRolesAsync(user); // This retrieves roles asynchronously

                // Populate the UserViewModel
                var userViewModel = new UserViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Roles = userRoles
                };

                userViewModels.Add(userViewModel);
            }

            return View(userViewModels);
        }


        public async Task<IActionResult> ManageRoles(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            var roles = await _roleManager.Roles.ToListAsync(); // Get all roles
            var userRoles = await _userManager.GetRolesAsync(user); // Get roles assigned to this user

            var model = new ManageUserRolesViewModel
            {
                UserId = user.Id,
                Roles = roles.ToDictionary(role => role.Name, role => userRoles.Contains(role.Name)) // Populate roles and assigned status
            };

            return View(model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateUserRoles(ManageUserRolesViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                return NotFound(); // User not found
            }

            // Retrieve the current roles of the user
            var currentRoles = await _userManager.GetRolesAsync(user);
            var allRoles = await _roleManager.Roles.Select(r => r.Name).ToListAsync(); // Get all available roles

            // Loop through each role in the submitted model
            foreach (var role in model.Roles)
            {
                if (role.Value && !currentRoles.Contains(role.Key)) // If the role is checked and the user does not have it
                {
                    // Add role to the user
                    var addResult = await _userManager.AddToRoleAsync(user, role.Key);
                    if (!addResult.Succeeded)
                    {
                        ModelState.AddModelError("", $"Failed to add role {role.Key}.");
                    }
                }
                else if (!role.Value && currentRoles.Contains(role.Key)) // If the role is unchecked and the user currently has it
                {
                    // Remove role from the user
                    var removeResult = await _userManager.RemoveFromRoleAsync(user, role.Key);
                    if (!removeResult.Succeeded)
                    {
                        ModelState.AddModelError("", $"Failed to remove role {role.Key}.");
                    }
                }
            }

            // If the ModelState has errors, return to the ManageRoles view to show them
            if (!ModelState.IsValid)
            {
                var roles = await _roleManager.Roles.ToListAsync();
                var userRoles = await _userManager.GetRolesAsync(user);

                var updatedModel = new ManageUserRolesViewModel
                {
                    UserId = user.Id,
                    Roles = roles.ToDictionary(role => role.Name, role => userRoles.Contains(role.Name))
                };

                return View("ManageRoles", updatedModel);
            }

            return RedirectToAction("Index"); // Redirect back to the user list after successful update
        }


    }
}
