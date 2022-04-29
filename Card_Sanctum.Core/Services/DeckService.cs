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

    public class DeckService : IDeckService
    {
        private readonly IRepository repo;

        public DeckService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<bool> CreateDeck(CreateDeckViewModel model, string id)
        {
            var result = false;
         

            var deck = new Deck()
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Description = model.Description,
                UserId = id
            };

            try
            {
                await repo.AddAsync(deck);
                await repo.SaveChangesAsync();
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            
            return result;
        }

        public async Task<CreateDeckViewModel> GetDeckForEdit(Guid id)
        {
            
                var deck = await repo.GetByIdAsync<Deck>(id);
            var deckCards = repo.All<Deck>().Include(x => x.Cards).Single(x => x.Id == deck.Id).Cards;

            var collection = new List<CardListViewModel>();

            foreach (var item in deckCards)
            {
                collection.Add(new CardListViewModel { Id = item.Id.ToString(), Name = item.Name, Type = item.CardType.ToString() });
            }

                return new CreateDeckViewModel()
                {
                    Id = deck.Id,
                    Name = deck.Name,
                    Description = deck.Description,
                    Cards = collection,
                };          
        }

        public async Task<IEnumerable<CreateDeckViewModel>> GetDecks(string id)
        {
            return await repo.All<Deck>().Where(u => u.UserId == id).Select
                (x => new CreateDeckViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description= x.Description  

                }).ToListAsync();
        }

        public async Task<bool> UpdateDeck(CreateDeckViewModel model)
        {
           
                bool result = false;

                var deck = await repo.GetByIdAsync<Deck>(model.Id);

                if (deck != null)
                {
                    deck.Name = model.Name;
                    deck.Description = model.Description;                        

                    await repo.SaveChangesAsync();

                    result = true;
                }

                return result;          
        }

        public async Task<bool> RemoveFromDeck(Guid deckId, Guid cardId)
        {         
            try
            {
                var deck = await repo.All<Deck>().Include(x => x.Cards).SingleOrDefaultAsync(x => x.Id == deckId);
                var card = deck.Cards.FirstOrDefault(x => x.Id == cardId);
                deck.Cards.Remove(card);
                await repo.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public async Task<bool> DeleteAsync(Guid deckId)
        {
            try
            {
               var deck = await repo.GetByIdAsync<Deck>(deckId);
                repo.Delete(deck);
                repo.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
