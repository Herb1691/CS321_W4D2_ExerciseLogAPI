using System;
using System.Collections.Generic;
using CS321_W4D2_ExerciseLogAPI.Core.Models;

namespace CS321_W4D2_ExerciseLogAPI.Core.Services
{
    public class ActivityTypeService : IActivityTypeService
    {
        private IActivityTypeRepository _activityTypeRepo;

        public ActivityTypeService(IActivityTypeRepository ActivityTypeRepo)
        {
            _activityTypeRepo = ActivityTypeRepo;
        }

        public ActivityType Add(ActivityType activityType)
        {
            // TODO: implement add
            _activityTypeRepo.Add(activityType);
            return activityType;
        }

        public ActivityType Get(int id)
        {
            // TODO: return the specified ActivityType using Find()
            return _activityTypeRepo.Get(id);
        }

        public IEnumerable<ActivityType> GetAll()
        {
            // TODO: return all ActivityTypes using ToList()
            return _activityTypeRepo.GetAll();
        }

        public ActivityType Update(ActivityType updatedActivityType)
        {
            // update the todo and save
            var activityType = _activityTypeRepo.Update(updatedActivityType);
            return activityType;
        }

        public void Remove(ActivityType activityType)
        {
            // TODO: remove the ActivityType
            _activityTypeRepo.Remove(activityType);
        }

    }

}
