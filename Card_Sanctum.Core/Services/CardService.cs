namespace Card_Sanctum.Core.Services
{
    using Card_Sanctum.Core.Models;
    using Card_Sanctum.Infrastructure.Data;
    using Card_Sanctum.Infrastructure.Data.Common.Repository;
    using Card_Sanctum.Infrastructure.Data.Identity;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CardService : ICardService
    {
        private readonly IRepository repo;

        public CardService(IRepository _repo)
        {
            repo = _repo;
        }

       public async Task<string> AddToCollection(string cardId, string userId)
       {
            if (string.IsNullOrEmpty(cardId) || string.IsNullOrEmpty(userId))
            {
                return "Неуспешно добавяне на карта във вашата колекция!";
            }
      
           var user = await repo.All<ApplicationUser>().Where(u => u.Id == userId).SingleOrDefaultAsync();
           var card = await repo.All<Card>().Where(c => c.Id.ToString() == cardId).SingleOrDefaultAsync();
           var userCards = repo.All<Card>().Where(c => c.Users.Any(u => u.Id == user.Id)).ToListAsync();

            if (userCards.Result.Contains(card))
            {
                return "Картата вече е във вашата колекция!";
            }

            user.Cards.Add(card);

            try
            {
               await repo.SaveChangesAsync();
            }
            catch (Exception)
            {

                return "Неуспешно добавяне в колекцията!";
                
            }

            return "Картата е добавена успешно!";
        }

        public async Task<string> AddToUserCollection(string cardId, string userId)
        {
            

            if (string.IsNullOrEmpty(cardId) || string.IsNullOrEmpty(userId))
            {
                return "Неуспешно добавяне на картата!";
            }

            var user = await repo.All<ApplicationUser>().Where(u => u.Id == userId).SingleOrDefaultAsync();
            var card = await repo.All<Card>().Where(c => c.Id.ToString() == cardId).SingleOrDefaultAsync();

            var userCards = repo.All<Card>().Where(c => c.Users.Any(u => u.Id == user.Id)).ToListAsync();

            if (userCards.Result.Contains(card))
            {
                return "Картата вече е във вашата колекция!";
            }

            if (user.Budget < card.Price)
            {
                return "Недостатъчно парички за картата!";
            }

            user.Cards.Add(card);

            try
            {
                user.Budget -= card.Price;
                await repo.SaveChangesAsync();

            }
            catch (Exception)
            {

                return "Неуспешно добавяне на картата!";

            }

            return "Успешно добавяне на картата!";
        }

        public async Task<bool> CreateCard(CreateCardViewModel model)
        {
           var result = true;
       

            Rarety currentRarety = (Rarety)Enum.Parse(typeof(Rarety), model.Rarety, true);
            CardType currentType = (CardType)Enum.Parse(typeof(CardType), model.CardType, true);
            Color currentColor = (Color)Enum.Parse(typeof(Color), model.Color);

            var card = new Card 
            {   
                Id = (Guid)model.Id, 
                Name = model.Name,
                Description = model.Description,
                Attack = model.Attack,
                Defense = model.Defense,
                Rarety = currentRarety,
                CardType = currentType,
                Color = currentColor,
                Price = model.Price,
                Quantity = model.Quantity,
            };

            repo.Add<Card>(card);


            repo.SaveChangesAsync();
            return result;
        }

        public async Task<Card> GetCardById(string id)
        {
            return await repo.GetByIdAsync<Card>(id);
        }

        public async Task<CardEditViewModel> GetCardForEdit(Guid id)
        {
            var card = await repo.GetByIdAsync<Card>(id);


            return new CardEditViewModel()
            { 
                Id = card.Id,
                Name = card.Name,
                Description = card.Description,
                CardType = card.CardType.ToString(),
                Color = card.Color.ToString(),
                Price = card.Price,
                Attack = card.Attack,
                Defense = card.Defense,
                Quantity = (int)card.Quantity,
                Rarety = card.Rarety.ToString()
            };
        }

        public async Task<IEnumerable<CardListViewModel>> GetCards()
        {
            return await repo.All<Card>().Select
                (x => new CardListViewModel()
                {                  
                    Id = x.Id.ToString(),
                    Name = x.Name,
                    Type = x.CardType.ToString(),

                }).ToListAsync();
        }

        public async Task<CardPagingViewModel> GetCardsForPaging(int pageNumber, int pageSize, string id = null)
        {

            CardPagingViewModel result = new CardPagingViewModel()
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            if (string.IsNullOrEmpty(id))
            {              
                result.TotalRecords = await repo.All<Card>().CountAsync();
                result.Cards = await repo.AllReadonly<Card>()
                    .OrderBy(c => c.Name)
                    .Skip(pageNumber * pageSize - pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                return result;
            }

            var user = await repo.All<ApplicationUser>().SingleOrDefaultAsync(u => u.Id == id);

            result.TotalRecords = await repo.All<Card>().Where(c => c.Users.Contains(user)).CountAsync();

            result.Cards = await repo.AllReadonly<Card>()
                .Where(c => c.Users.Contains(user))
                .OrderBy(c => c.Name)
                .Skip(pageNumber * pageSize - pageSize)
                .Take(pageSize)
                .ToListAsync();

            return result;
            
        }

        public async Task<bool> UpdateCard(CardEditViewModel model)
        {
            bool result = false;

            var card = await repo.GetByIdAsync<Card>(model.Id);

            if (card != null)
            {
                card.Name = model.Name;
                card.Description = model.Description;
                card.CardType = (CardType)Enum.Parse(typeof(CardType), model.CardType);
                card.Color = (Color)Enum.Parse(typeof(Color), model.Color);
                card.Price = model.Price;
                card.Attack = model.Attack;
                card.Defense = model.Defense;
                card.Quantity = model.Quantity;
                card.Rarety = (Rarety)Enum.Parse(typeof(Rarety), model.Rarety);
                
                await repo.SaveChangesAsync();

                result = true;
            }

            return result;
        }
    }
}
