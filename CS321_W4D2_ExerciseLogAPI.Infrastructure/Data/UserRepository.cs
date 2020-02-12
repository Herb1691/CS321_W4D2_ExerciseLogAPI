using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS321_W4D2_ExerciseLogAPI.Core.Services;
using CS321_W4D2_ExerciseLogAPI.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CS321_W4D2_ExerciseLogAPI.Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public User Add(User user)
        {
            // TODO: implement add
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user;
        }

        public User Get(int id)
        {
            // TODO: return the specified User using Find()
            return _dbContext.Users
                .Include(u => u.Activities)
                .SingleOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            // TODO: return all Users using ToList()
            return _dbContext.Users
                .Include(u => u.Activities)
                .ToList();
        }

        public User Update(User updatedUser)
        {
            // get the ToDo object in the current list with this id 
            var currentUser = _dbContext.Users.Find(updatedUser.Id);

            // return null if todo to update isn't found
            if (currentUser == null) return null;

            // NOTE: This method is already completed for you, but note
            // how the property values are copied below.

            // copy the property values from the changed todo into the
            // one in the db. NOTE that this is much simpler than individually
            // copying each property.
            _dbContext.Entry(currentUser)
                .CurrentValues
                .SetValues(updatedUser);

            // update the todo and save
            _dbContext.Users.Update(currentUser);
            _dbContext.SaveChanges();

            // update the todo and save
            return currentUser;
        }

        public void Remove(User user)
        {
            // TODO: remove the User
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }
    }
}
