namespace Card_Sanctum.Areas.Admin.Controllers
{
    using Card_Sanctum.Core.Constants;
    using Card_Sanctum.Core.Models;
    using Card_Sanctum.Core.Services;
    using Microsoft.AspNetCore.Mvc;

    public class BoosterController : BaseController
    {
        private readonly IBoosterPackService boosterPackService;

        public BoosterController(IBoosterPackService _boosterPackService)
        {
            boosterPackService = _boosterPackService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Create()
         {
            return View();
         }

        [HttpPost]
        public async Task<IActionResult> Create(BoosterListViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await boosterPackService.Create(model))
            {
                ViewData[MessageConstants.SuccessMessage] = "Бустерът беше създаден успешно!";

                return RedirectToAction(nameof(Create));
            }

            else
            {
                ViewData[MessageConstants.ErrorMessage] = "Неуспешно създаване!";
            }

            return View(model);
        }
    }
}
