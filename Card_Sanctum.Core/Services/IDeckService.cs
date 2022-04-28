namespace Card_Sanctum.Core.Services
{
    using Card_Sanctum.Core.Models;
    using Card_Sanctum.Infrastructure.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IDeckService
    {
        Task<bool> CreateDeck(CreateDeckViewModel model, string id);

        Task<IEnumerable<CreateDeckViewModel>> GetDecks(string id);

        Task<CreateDeckViewModel> GetDeckForEdit(string id);

        Task<bool> UpdateDeck(CreateDeckViewModel model);

    }
}
