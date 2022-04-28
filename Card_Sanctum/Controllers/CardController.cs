namespace Card_Sanctum.Controllers
{
    using Card_Sanctum.Core.Constants;
    using Card_Sanctum.Core.Models;
    using Card_Sanctum.Core.Services;
    using Card_Sanctum.Infrastructure.Data.Identity;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class CardController : BaseController
    {
        private ICardService cardService;

        private UserManager<ApplicationUser> userManager;
        private readonly IDeckService deckService;

        public CardController(ICardService _cardService, UserManager<ApplicationUser> _userManager, IDeckService _deckService)
        {
            cardService = _cardService;
            userManager = _userManager;
            deckService = _deckService;
        }

        public async Task<IActionResult> Index(int p = 1, int s = 10, string message = null)
        {
            var model = await cardService.GetCardsForPaging(p, s);

            if (!string.IsNullOrEmpty(message))
            {
                ViewData[MessageConstants.InfoMessage] = message;
            }

            return View(model);
        }

        public async Task<IActionResult> UserCards(int p = 1, int s = 10, string message = null)
        {
            var user = await userManager.GetUserAsync(User);

            var userId = await userManager.GetUserIdAsync(user);

            var model = await cardService.GetCardsForPaging(p, s, userId);
          
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToUserCollection(string id)
        {

            string result = await cardService.AddToUserCollection(id, userManager.GetUserId(User));
           
            
            return this.RedirectToAction(nameof(this.Index), "Card", new {message = result});
        }

        public async Task<IActionResult> AddToDeck(string id)
        {
            var userId = userManager.GetUserId(User);

            var user = await userManager.GetUserAsync(User);

            var userDecks = deckService.GetDecks(userId);

            var model = new UserDecksViewModel
            {
                CardId = id,
                UserId = userId,
                Name = $"{user.FirstName} your decks:",              
            };

            ViewBag.DeckItems = userDecks.Result
                .ToList()
                .Select(d => new SelectListItem()
                {
                    Text = d.Name,
                    Value = d.Id.ToString(),
                    Selected = false                  
                }).ToList();           
               

            return View(model);
        }

       [HttpPost]
       public async Task<IActionResult> Add(UserDecksViewModel model)
       {
            var cardId = model.CardId;
            var deckId = model.DeckNames.GetValue(0).ToString();

            try
            {
                await cardService.Add(cardId, deckId);
                ViewData[MessageConstants.SuccessMessage] = "Картата беше добавена успешно!";
            }
            catch (Exception)
            {

                ViewData[MessageConstants.SuccessMessage] = "Неупешно добавяне!";
            }



            return Redirect(nameof(Index));
       }
    }
}
