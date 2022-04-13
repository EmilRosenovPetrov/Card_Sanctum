namespace Card_Sanctum.Areas.Admin.Controllers
{
    using Card_Sanctum.Core.Constants;
    using Card_Sanctum.Core.Models;
    using Card_Sanctum.Core.Services;
    using Card_Sanctum.Infrastructure.Data.Identity;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
 

    public class UserController : BaseController
    {
        private readonly RoleManager<IdentityRole> roleManager;

        private readonly UserManager<ApplicationUser> userManager;

        private readonly IUserService service;

        public UserController(
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
            return View();
        }

        public async Task<IActionResult> ManageUsers()
        {
            var users = await service.GetUsers();

            return View(users);
        }

        public async Task<IActionResult> Roles(string id)
        {
            var user = await service.GetUserById(id);

            var model = new UserRolesViewModel()
            {
                UserId = user.Id,
                Name = $"{user.FirstName} {user.PatronymicName} {user.LastName}"
            };

            ViewBag.RoleItems = roleManager.Roles
                .ToList()
                .Select( r => new SelectListItem()
                {
                    Text = r.Name,
                    Value = r.Name,
                    Selected =  userManager.IsInRoleAsync(user, r.Name).Result
                }).ToList();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Roles(UserRolesViewModel model)
        {
            return Ok(model);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var model = await service.GetUserForEdit(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await service.UpdateUser(model))
            {
                ViewData[MessageConstants.SuccessMessage] = "Успешна корекция!";
            }

            else
            {
                ViewData[MessageConstants.ErrorMessage] = "Неуспешен запис!";
            }

            return View(model);
        }

      // public async Task<IActionResult> CreateRole()
      // {
      //     await roleManager.CreateAsync(new IdentityRole
      //     {
      //         Name = "Planeswalker"
      //     });
      //
      //     return Ok();
      // }
    }
}
