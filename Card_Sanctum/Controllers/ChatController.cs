namespace Card_Sanctum.Controllers
{
    using Card_Sanctum.Core.Constants;
    using Card_Sanctum.Core.Services;
    using Card_Sanctum.Infrastructure.Data.Identity;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ChatController : BaseController
    {
        private readonly RoleManager<IdentityRole> roleManager;

        private readonly UserManager<ApplicationUser> userManager;

        private readonly IUserService service;

        public ChatController(
            RoleManager<IdentityRole> _roleManager,
            UserManager<ApplicationUser> _userManager,
            IUserService _service)
        {
            service = _service;
            roleManager = _roleManager;
            userManager = _userManager;
        }

        public IActionResult Index()
        {
            ViewData[MessageConstants.SuccessMessage] = "Добре дошли на ЧАТ страницата!";

            var appUser = userManager.GetUserAsync(User);

            ViewBag.Username = $"{appUser.Result.FirstName} {appUser.Result.LastName}";

            return View();
        }
    }
}
