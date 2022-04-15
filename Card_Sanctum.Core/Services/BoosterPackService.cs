namespace Card_Sanctum.Core.Services
{
    using Card_Sanctum.Core.Models;
    using Card_Sanctum.Infrastructure.Data;
    using Card_Sanctum.Infrastructure.Data.Common;
    using Card_Sanctum.Infrastructure.Data.Common.Repository;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BoosterPackService : IBoosterPackService

    {
        private readonly IRepository repo;

        public BoosterPackService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<bool> Create(BoosterListViewModel model)
        {
            var result = false;

            var booster = new BoosterPack
            {
                Id = model.Id,
                Edition = model.Edition,
                BoosterPrice = model.Price,
                CardCount = BoosterAndCardConstants.BoosterCardCount,
                
            };         

            var commonCards = repo.All<Card>().Where(c => c.Rarety == Rarety.common).ToList();

            var uncommonCards = repo.All<Card>().Where(c => c.Rarety == Rarety.uncommon).ToList();

            var rareCards = repo.All<Card>().Where(c => c.Rarety == Rarety.rare || c.Rarety == Rarety.legendary).ToList();

            var cardsToAdd = new List<BoosterPackCard>();

            if (commonCards.Count < 6 || uncommonCards.Count < 3 || rareCards.Count < 1)
            {
                return result;
            }
            

            Random random = new Random();


            for (int i = 0; i < 5; i++)
            {
                int index = random.Next(0, commonCards.Count - 1);
                cardsToAdd.Add(new BoosterPackCard
                {
                    BoosterPackId = booster.Id,
                    CardId = commonCards[index].Id,
                });
            }

            for (int i = 0; i < 4; i++)
            {
                int index = random.Next(0, uncommonCards.Count - 1);
                cardsToAdd.Add(new BoosterPackCard
                {
                    BoosterPackId = booster.Id,
                    CardId = uncommonCards[index].Id,
                });
            }

            int next = random.Next(0, rareCards.Count - 1);
            cardsToAdd.Add(new BoosterPackCard
            {
                BoosterPackId = booster.Id,
                CardId = rareCards[next].Id,
            });

            booster.Cards = cardsToAdd;

            try
            {
                repo.Add(cardsToAdd);
                repo.Add(booster);
                repo.SaveChanges();
                result = true;               
            }
            catch (Exception)
            {

                result = false;            
            }

            return result;  
        }

        public Task<IEnumerable<BoosterListViewModel>> GetBooster()
        {
            throw new NotImplementedException();
        }
    }
}
