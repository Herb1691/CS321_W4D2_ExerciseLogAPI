using System;
using System.Collections.Generic;
using System.Linq;
using CS321_W4D2_ExerciseLogAPI.Core.Models;

namespace CS321_W4D2_ExerciseLogAPI.ApiModels
{
    public static class ActivityMappingExtenstions
    {

        public static ActivityModel ToApiModel(this Activity activity)
        {
            return new ActivityModel
            {
                Id = activity.Id,
                // TODO: fill in property mappings
                Date = activity.Date,
                Duration = activity.Duration,
                Notes = activity.Notes,
                // TODO: the ActivityType property should contain the name of the activity type
                ActivityType = activity.ActivityType != null
                    ? activity.ActivityType.Name + " " + activity.ActivityType.RecordType
                    : null,
                // TODO: the User property should contain the user's name
                User = activity.User != null
                    ? activity.User.Name
                    : null
            };
        }

        public static Activity ToDomainModel(this ActivityModel activityModel)
        {
            return new Activity
            {
                Id = activityModel.Id,
                // TODO: fill in property mappings
                // TODO: leave User and ActivityType null
                Date = activityModel.Date,
                Duration = activityModel.Duration,
                Notes = activityModel.Notes,
                ActivityTypeId = activityModel.ActivityTypeId,
                UserId = activityModel.UserId
            };
        }

        public static IEnumerable<ActivityModel> ToApiModels(this IEnumerable<Activity> activities)
        {
            return activities.Select(a => a.ToApiModel()).ToList();
        }

        public static IEnumerable<Activity> ToDomainModels(this IEnumerable<ActivityModel> activityModels)
        {
            return activityModels.Select(a => a.ToDomainModel());
        }
    }
}
