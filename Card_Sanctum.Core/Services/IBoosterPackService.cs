namespace Card_Sanctum.Core.Services
{
    using Card_Sanctum.Core.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IBoosterPackService
    {
        Task<bool> Create(BoosterListViewModel model);

        Task<IEnumerable<BoosterListViewModel>> GetBooster();
    }
}
