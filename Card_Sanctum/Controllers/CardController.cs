namespace Card_Sanctum.Controllers
{
    using Card_Sanctum.Core.Constants;
    using Card_Sanctum.Core.Services;
    using Card_Sanctum.Infrastructure.Data.Identity;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class CardController : BaseControler
    {
        private ICardService cardService;

        private UserManager<ApplicationUser> userManager;

        public CardController(ICardService _cardService, UserManager<ApplicationUser> _userManager)
        {
            cardService = _cardService;
            userManager = _userManager;
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

        [HttpPost]
        public async Task<IActionResult> AddToUserCollection(string id)
        {
            

            string result = await cardService.AddToUserCollection(id, userManager.GetUserId(User));
           
            
            return this.RedirectToAction(nameof(this.Index), "Card", new {message = result});
        }
    }
}
