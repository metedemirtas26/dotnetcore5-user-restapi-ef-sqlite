using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Business
{
    public interface IUserService
    {
        User get(int id);

        IQueryable<User> getAll();

        User add(User user);

        void update(User user);

        void delete(int id);
    }
}
