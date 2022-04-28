namespace Card_Sanctum.Controllers
{
    using Card_Sanctum.Core.Constants;
    using Card_Sanctum.Core.Models;
    using Card_Sanctum.Core.Services;
    using Card_Sanctum.Infrastructure.Data.Identity;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class DeckController : BaseController
    {
        private readonly IDeckService deckService;
        private readonly UserManager<ApplicationUser> userManager;

        public DeckController(IDeckService _deckService, UserManager<ApplicationUser> _userManager)
        {
            deckService = _deckService;
            userManager = _userManager;
        }

        public async Task<IActionResult> Index(string message = null)
        {
            var userId = userManager.GetUserId(User);

            var model = await deckService.GetDecks(userId);

            if (!string.IsNullOrEmpty(message))
            {
                ViewData[MessageConstants.InfoMessage] = message;
            }

            if (!model.Any())
            {
                return Redirect("deck/create");
            }

            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDeckViewModel model)
        {
            var userId = userManager.GetUserId(User);

            if (!ModelState.IsValid)
            {
                ViewData[MessageConstants.ErrorMessage] = "Невалидни данни!";
                return View(model);
            }

            if (await deckService.CreateDeck(model, userId))
            {            

                return RedirectToAction(nameof(Index), ViewData[MessageConstants.SuccessMessage] = "Тестето беше създадено успешно!");
            }


            ViewData[MessageConstants.ErrorMessage] = "Неуспешно създаване!";


            return View(model);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var model = await deckService.GetDeckForEdit(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CreateDeckViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await deckService.UpdateDeck(model))
            {
                ViewData[MessageConstants.SuccessMessage] = "Тестето беше коригирано успешно!";
            }

            else
            {
                ViewData[MessageConstants.ErrorMessage] = "Неуспешна корекция!";
            }

            return View(model);
        }
    }

}
