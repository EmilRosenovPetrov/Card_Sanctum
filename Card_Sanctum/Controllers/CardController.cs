namespace Card_Sanctum.Controllers
{
    using Card_Sanctum.Core.Services;
    using Microsoft.AspNetCore.Mvc;

    public class CardController : BaseControler
    {
        private ICardService cardService;

        public CardController(ICardService _cardService)
        {
            cardService = _cardService;
        }

        public async Task<IActionResult> Index(int p = 1, int s = 10)
        {
            var model = await cardService.GetCardsForPaging(p, s);

            return View(model);
        }
    }
}
