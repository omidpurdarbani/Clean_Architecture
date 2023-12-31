﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Domain.Interfaces;
using Domain.Models;

namespace Data.Repository
{
    public 
        class UserRepository : IUserRepository
    {
        private UniversityDbContext _context;

        public UserRepository(UniversityDbContext context)
        {
            _context = context;
        }
        
        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(p => p.Email == email);
        }

        public void AddUser(User user)
        {
            _context.Add(user);
        }

        public bool IsExistUserName(string userName)
        {
            return _context.Users.Any(u => u.UserName == userName);
        }

        public bool IsExistEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public bool IsExistUser(string email, string password)
        {
            return _context.Users.Any(p => p.Email == email && p.Password == password);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
