namespace Card_Sanctum.Core.Services
{
    using Card_Sanctum.Core.Models;
    using Card_Sanctum.Infrastructure.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICardService
    {
        Task<IEnumerable<CardListViewModel>> GetCards();

        Task<CardPagingViewModel> GetCardsForPaging(int pageNumber, int pageSize, string id = null);

        Task<CardEditViewModel> GetCardForEdit(Guid id);

        Task<bool> CreateCard(CreateCardViewModel model);

        Task<bool> UpdateCard(CardEditViewModel model);

        Task<Card> GetCardById(string id);

        Task<string> AddToCollection(string cardId, string userId);

        Task<string> AddToUserCollection(string cardId, string userId);
    }
}
