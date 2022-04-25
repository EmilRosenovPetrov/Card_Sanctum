namespace Card_Sanctum.Core.Services
{
    using Card_Sanctum.Core.Models;
    using Card_Sanctum.Infrastructure.Data.Common.Repository;
    using Card_Sanctum.Infrastructure.Data.Identity;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class UserService : IUserService
    {

        private readonly IRepository repo;

        public UserService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<ApplicationUser> GetUserById(string id)
        {
            return await repo.GetByIdAsync<ApplicationUser>(id);
        }

        public async Task<UserEditViewModel> GetUserForEdit(string id)
        {
            var user = await repo.GetByIdAsync<ApplicationUser>(id);

            return new UserEditViewModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                PatronimicName = user.PatronymicName,
                LastName = user.LastName,
            };
        }

        public async Task<IEnumerable<UserListViewModel>> GetUsers()
        {
            return await repo.All<ApplicationUser>().Select
                (x => new UserListViewModel()
                {
                    Email = x.Email,
                    Id = x.Id,
                    Name = $"{x.FirstName} {x.PatronymicName} {x.LastName}"
                }).ToListAsync();
        }

        public async Task<bool> UpdateUser(UserEditViewModel model)
        {
            bool result = false;

            var user = await repo.GetByIdAsync<ApplicationUser>(model.Id);

            if (user != null)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.PatronymicName = model.PatronimicName;
                user.Budget = (decimal)model.Budget;

                await repo.SaveChangesAsync();

                result = true;
            }

            return result;
        }
    }
}
