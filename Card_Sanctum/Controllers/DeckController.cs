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

        public async Task<IActionResult> Index()
        {
            var userId = userManager.GetUserId(User);

            var model = await deckService.GetDecks(userId);


            ViewData[MessageConstants.SuccessMessage] = TempData[MessageConstants.SuccessMessage];
            ViewData[MessageConstants.ErrorMessage] = TempData[MessageConstants.ErrorMessage];


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
                TempData[MessageConstants.ErrorMessage] = "Невалидни данни!";
                return View(model);
            }

            if (await deckService.CreateDeck(model, userId))
            {

                return RedirectToAction(nameof(Index), TempData[MessageConstants.SuccessMessage] = "Тестето беше създадено успешно!");
            }

            return RedirectToAction(nameof(Index), TempData[MessageConstants.ErrorMessage] = "Неуспешно създаване!");
        }

        public async Task<IActionResult> Edit(Guid id)
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
                TempData[MessageConstants.SuccessMessage] = "Тестето беше коригирано успешно!";
            }

            else
            {
                TempData[MessageConstants.ErrorMessage] = "Неуспешна корекция!";
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemoveFromDeck(Guid deckId, Guid cardId)
        {
            if (await deckService.RemoveFromDeck(deckId, cardId))
            {
                TempData[MessageConstants.SuccessMessage] = "Картата беше премахната успешно!";
            }

            else
            {
                TempData[MessageConstants.ErrorMessage] = "Неуспешнo премахване!";
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid Id)
        {
            if (await deckService.DeleteAsync(Id))
            {
                TempData[MessageConstants.SuccessMessage] = "Тестето беше премахнато успешно!";
            }
            else
            {
                TempData[MessageConstants.ErrorMessage] = "Неуспешнo премахване!";
            }
            return RedirectToAction(nameof(Index));
        }
    }

}
