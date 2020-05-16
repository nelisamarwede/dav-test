using DAV.Domain.EF.Context;
using DAV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAV.Domain.EF.Commands
{
    public class UserCommands : CommandBase
    {
        public UserCommands(ApplicationContext applicationContext) : base(applicationContext)
        {

        }

        public User AddUser(User user)
        {
            user.IsActive = true;

            _context.Add(user);
            _context.SaveChanges();
            return user;
        }

        public bool UpdateUser(User user)
        {
            _context.Attach(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.Update(user);

            _context.SaveChanges();

            return true;
        }

        public void DeleteUser(User user)
        {

            _context.Attach(user).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }
    }
}
