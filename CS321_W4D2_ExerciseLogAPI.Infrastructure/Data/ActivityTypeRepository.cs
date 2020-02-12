using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS321_W4D2_ExerciseLogAPI.Core.Services;
using CS321_W4D2_ExerciseLogAPI.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CS321_W4D2_ExerciseLogAPI.Infrastructure.Data
{
    public class ActivityTypeRepository : IActivityTypeRepository
    {
        private readonly AppDbContext _dbContext;

        public ActivityTypeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActivityType Add(ActivityType activityType)
        {
            // TODO: implement add
            _dbContext.ActivityTypes.Add(activityType);
            _dbContext.SaveChanges();
            return activityType;
        }

        public ActivityType Get(int id)
        {
            // TODO: return the specified User using Find()
            return _dbContext.ActivityTypes
                .SingleOrDefault(a => a.Id == id);
        }

        public IEnumerable<ActivityType> GetAll()
        {
            // TODO: return all Users using ToList()
            return _dbContext.ActivityTypes.ToList();
        }

        public ActivityType Update(ActivityType updatedActivityType)
        {
            // get the ToDo object in the current list with this id 
            var currentActivityType = _dbContext.ActivityTypes.Find(updatedActivityType.Id);

            // return null if todo to update isn't found
            if (currentActivityType == null) return null;

            // NOTE: This method is already completed for you, but note
            // how the property values are copied below.

            // copy the property values from the changed todo into the
            // one in the db. NOTE that this is much simpler than individually
            // copying each property.
            _dbContext.Entry(currentActivityType)
                .CurrentValues
                .SetValues(updatedActivityType);

            // update the todo and save
            _dbContext.ActivityTypes.Update(currentActivityType);
            _dbContext.SaveChanges();

            // update the todo and save
            return currentActivityType;
        }

        public void Remove(ActivityType activityType)
        {
            // TODO: remove the User
            _dbContext.ActivityTypes.Remove(activityType);
            _dbContext.SaveChanges();
        }
    }
}
