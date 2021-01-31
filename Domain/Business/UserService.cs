using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Business
{
    public class UserService : IUserService
    {
        private readonly UsersDbContext _context;

        public UserService(UsersDbContext context)
        {
            _context = context;
        }

        public User add(User user)
        {
            User newUser =_context.Users.Add(user).Entity;
            _context.SaveChanges();
            return newUser;
        }

        public User get(int id)
        {
            return _context.Users
                .FirstOrDefault(m => m.Id == id);
        }

        public IQueryable<User> getAll()
        {
            return _context.Users;
        }

        public void update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void delete(int id)
        {
            User user = get(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

    }
}
