using System;
using System.Collections.Generic;
using CS321_W4D2_ExerciseLogAPI.Core.Models;

namespace CS321_W4D2_ExerciseLogAPI.Core.Services
{
    public class ActivityService : IActivityService
    {
        private IActivityRepository _activityRepo;
        private IActivityTypeRepository _activityTypeRepo;

        public ActivityService(IActivityRepository activityRepo, IActivityTypeRepository activityTypeRepo)
        {
            _activityRepo = activityRepo;
            _activityTypeRepo = activityTypeRepo;
        }

        public Activity Add(Activity activity)
        {
            // retrieve the ActivityType so we can check
            var activityType = _activityTypeRepo.Get(activity.ActivityTypeId);
            // for a DurationAndDistance activity, you must supply a Distance
            if (activityType.RecordType == RecordType.DurationAndDistance
                && activity.Distance <= 0)
            {
                throw new ApplicationException("You must supply a Distance for this activity.");
            }
            _activityRepo.Add(activity);
            return activity;
        }

        public Activity Get(int id)
        {
            // TODO: return the specified Activity using Find()
            return _activityRepo.Get(id);
        }

        public IEnumerable<Activity> GetAll()
        {
            // TODO: return all Activitys using ToList()
            return _activityRepo.GetAll();
        }

        public Activity Update(Activity updatedActivity)
        {
            // update the todo and save
            var activity = _activityRepo.Update(updatedActivity);
            return activity;
        }

        public void Remove(Activity activity)
        {
            // TODO: remove the Activity
            _activityRepo.Remove(activity);
        }

    }

}