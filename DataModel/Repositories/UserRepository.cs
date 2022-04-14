﻿using DataModel.Data;
using DataModel.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DataContext _dataDbContext;
        public UsersRepository(DataContext dataDbContext)
        {
            _dataDbContext = dataDbContext;
        }

        public async Task<List<AppUser>> GetAllUsersAsync()
        {
            List<AppUser> users = null;
            users = await _dataDbContext.Users.ToListAsync();
            return users;
        }

        public async Task<AppUser> AddUserAsync(AppUser user)
        {
            _dataDbContext.Users.Add(user);
            await _dataDbContext.SaveChangesAsync();
            return user;
        }
    }
}
public interface IUsersRepository
{
    Task<List<AppUser>> GetAllUsersAsync();
    Task<AppUser> AddUserAsync(AppUser user);
}