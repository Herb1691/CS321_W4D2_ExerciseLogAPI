using System.Collections.Generic;
using CS321_W4D2_ExerciseLogAPI.Core.Models;

namespace CS321_W4D2_ExerciseLogAPI.Core.Services
{
    public interface IActivityService
    {
        Activity Add(Activity activity);
        Activity Get(int id);
        IEnumerable<Activity> GetAll();
        void Remove(Activity activity);
        Activity Update(Activity updatedActivity);
    }
}