﻿using Microsoft.EntityFrameworkCore;
using Web.Domain.Entity;
using Web.Domain.Repositories;

namespace Web.Infastructure;
internal class UserRepository : IUserRepository
{
    private readonly ApplicationContext _context;

    public UserRepository(ApplicationContext context)
    {
        _context = context;
    }

    public void AddUser(User user)
    {
        _context.Users.Add(user);
    }

    public User? GetUser(int userId)
    {
        return _context.Users.FirstOrDefault(x => x.Id == userId);
    }

    public List<User> GetAllUsers()
    {
        return _context.Users.ToList();
    }
}