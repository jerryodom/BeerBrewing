using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BeerBrewingWithReactBoilerplate.Models;

namespace BeerBrewingWithReactBoilerplate.Controllers.Status
{
    public class StatusController : BaseController
    {
        public StatusController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
            :base(userManager, signInManager)
        {
        }

        [Route("status/status/{statusCode}")]
        public async Task<IActionResult> Status(int statusCode)
        {
            return View($"js-/statuscode{statusCode}", await BuildState());
        }
    }
}
