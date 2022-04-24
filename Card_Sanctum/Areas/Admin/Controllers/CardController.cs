namespace Card_Sanctum.Areas.Admin.Controllers
{
    using Card_Sanctum.Core.Constants;
    using Card_Sanctum.Core.Models;
    using Card_Sanctum.Core.Services;
    using Card_Sanctum.Infrastructure.Data;
    using Card_Sanctum.Infrastructure.Data.Identity;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class CardController : BaseController
    {
        private ICardService cardService;

        private readonly UserManager<ApplicationUser> userManager;

        public CardController(ICardService _cardService, UserManager<ApplicationUser> _userManager)
        {
            cardService = _cardService;
            userManager = _userManager;
        }

        public async Task<IActionResult> Index(int p = 1, int s = 10, string message = null)
        {
            var model = await cardService.GetCardsForPaging(p, s);
           
            return View(model);
        }

        public async Task<IActionResult> ManageCards()
        {
            var cards = await cardService.GetCards();

            return View(cards);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var model = await cardService.GetCardForEdit(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CardEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await cardService.UpdateCard(model))
            {
                ViewData[MessageConstants.SuccessMessage] = "Картата беше коригирана успешно!";
            }

            else
            {
                ViewData[MessageConstants.ErrorMessage] = "Неуспешна корекция!";
            }

            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCardViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await cardService.CreateCard(model))
            {
                ViewData[MessageConstants.SuccessMessage] = "Картата беше създадена успешно!";

                return RedirectToAction(nameof(Create), ViewData[MessageConstants.SuccessMessage] = "Картата беше създадена успешно!");
            }

            else
            {
                ViewData[MessageConstants.ErrorMessage] = "Неуспешно създаване!";
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(string id)
        {
            if (await cardService.AddToCollection(id, userManager.GetUserId(User)))
            {
                ViewData[MessageConstants.SuccessMessage] = "Картата беше добавена успешно!";
            }
            else
            {
                ViewData[MessageConstants.ErrorMessage] = "Картата не беше добавена успешно!";
            }

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
