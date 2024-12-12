using Lab3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lab3.ViewComponents
{
    public class ProfilePictureViewComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfilePictureViewComponent(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ApplicationUser user = null;

            if (User.Identity.IsAuthenticated)
            {
                user = await _userManager.GetUserAsync(HttpContext.User);
            }

            return View(user);
        }
    }
}
