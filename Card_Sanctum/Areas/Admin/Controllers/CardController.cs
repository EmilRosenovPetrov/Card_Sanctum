namespace Card_Sanctum.Areas.Admin.Controllers
{
    using Card_Sanctum.Core.Services;
    using Microsoft.AspNetCore.Mvc;

    public class CardController : BaseController
    {
        private ICardService cardService;

        public CardController(ICardService _cardService)
        {
            cardService = _cardService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ManageCards()
        {
            var cards = await cardService.GetCards();

            return View(cards);
        }
    }
}
