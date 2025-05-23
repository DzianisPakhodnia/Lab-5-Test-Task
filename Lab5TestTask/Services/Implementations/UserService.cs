﻿using Lab5TestTask.Data;
using Lab5TestTask.Enums;
using Lab5TestTask.Models;
using Lab5TestTask.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab5TestTask.Services.Implementations;

/// <summary>
/// UserService implementation.
/// Implement methods here.
/// </summary>
public class UserService : IUserService
{
    private readonly ApplicationDbContext _dbContext;

    public UserService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<User> GetUserAsync()
    {
        return await _dbContext.Users
            .OrderByDescending(user => user.Sessions.Count)
            .FirstOrDefaultAsync();
    }

    public async Task<List<User>> GetUsersAsync()
    {
        return await _dbContext.Users
            .Where(user => user.Sessions
            .Any(x => x.DeviceType == DeviceType.Mobile))
            .ToListAsync();

    }
}
