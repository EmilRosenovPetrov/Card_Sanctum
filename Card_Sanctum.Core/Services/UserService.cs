﻿namespace Card_Sanctum.Core.Services
{
    using Card_Sanctum.Core.Models;
    using Card_Sanctum.Infrastructure.Data.Common.Repository;
    using Card_Sanctum.Infrastructure.Data.Identity;
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
    }
}