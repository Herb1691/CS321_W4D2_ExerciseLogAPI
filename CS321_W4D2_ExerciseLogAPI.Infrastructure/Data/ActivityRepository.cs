using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS321_W4D2_ExerciseLogAPI.Core.Services;
using CS321_W4D2_ExerciseLogAPI.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CS321_W4D2_ExerciseLogAPI.Infrastructure.Data
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly AppDbContext _dbContext;
        public ActivityRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Activity Add(Activity activity)
        {
            // TODO: implement add
            _dbContext.Activities.Add(activity);
            _dbContext.SaveChanges();
            return activity;
        }

        public Activity Get(int id)
        {
            // TODO: return the specified User using Find()
            return _dbContext.Activities
                .Include(a => a.User)
                .Include(a => a.ActivityType)
                .SingleOrDefault(a => a.Id == id);
        }

        public IEnumerable<Activity> GetAll()
        {
            // TODO: return all Users using ToList()
            return _dbContext.Activities
                .Include(a => a.User)
                .Include(a => a.ActivityType)
                .ToList();
        }

        public Activity Update(Activity updatedActivity)
        {
            // get the ToDo object in the current list with this id 
            var currentActivity = _dbContext.Activities.Find(updatedActivity.Id);

            // return null if todo to update isn't found
            if (currentActivity == null) return null;

            // NOTE: This method is already completed for you, but note
            // how the property values are copied below.

            // copy the property values from the changed todo into the
            // one in the db. NOTE that this is much simpler than individually
            // copying each property.
            _dbContext.Entry(currentActivity)
                .CurrentValues
                .SetValues(updatedActivity);

            // update the todo and save
            _dbContext.Activities.Update(currentActivity);
            _dbContext.SaveChanges();

            // update the todo and save
            return currentActivity;
        }

        public void Remove(Activity activity)
        {
            // TODO: remove the User
            _dbContext.Activities.Remove(activity);
            _dbContext.SaveChanges();
        }
    }
}
