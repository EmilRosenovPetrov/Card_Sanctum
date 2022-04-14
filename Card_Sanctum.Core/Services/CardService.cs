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

        public async Task<bool> CreateCard(CardEditViewModel model)
        {
            var result = true;

            if (repo.GetByIdAsync<Card>(model.Id) != null)
            {
                result = false;
            }

            repo.Add<Card>(new Card()
            {
                Name = model.Name,
                Description = model.Description,
                Attack = model.Attack,
                Defense = model.Defense,
                Rarety = (Rarety)Enum.Parse(typeof(Rarety), model.Rarety),
                CardType = (CardType)Enum.Parse(typeof(CardType), model.CardType),
                Color = (Color)Enum.Parse(typeof(Color), model.Rarety),
                Price = model.Price,
                Quantity = model.Quantity,               
            });

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
