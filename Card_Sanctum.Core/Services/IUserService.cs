namespace Card_Sanctum.Core.Services
{
    using Card_Sanctum.Core.Models;
    using Card_Sanctum.Infrastructure.Data.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IUserService
    {
        Task<IEnumerable<UserListViewModel>> GetUsers();

        Task<UserEditViewModel> GetUserForEdit(string id);


        Task<bool> UpdateUser(UserEditViewModel model);
    }
}
