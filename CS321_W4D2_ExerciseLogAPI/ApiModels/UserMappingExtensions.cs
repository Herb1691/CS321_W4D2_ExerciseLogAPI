using System;
using System.Collections.Generic;
using System.Linq;
using CS321_W4D2_ExerciseLogAPI.Core.Models;

namespace CS321_W4D2_ExerciseLogAPI.ApiModels
{
    public static class UserMappingExtenstions
    {

        public static UserModel ToApiModel(this User user)
        {
            return new UserModel
            {
                Id = user.Id,
                // TODO: fill in property mappings
                Name = user.Name,
                Activities = user.Activities.ToApiModels().ToList()
            };
        }

        public static User ToDomainModel(this UserModel userModel)
        {
            return new User
            {
                Id = userModel.Id,
                // TODO: fill in property mappings
                Name = userModel.Name,
                Activities = userModel.Activities.ToDomainModels().ToList()
            };
        }

        public static IEnumerable<UserModel> ToApiModels(this IEnumerable<User> users)
        {
            return users.Select(a => a.ToApiModel());
        }

        public static IEnumerable<User> ToDomainModels(this IEnumerable<UserModel> userModels)
        {
            return userModels.Select(a => a.ToDomainModel());
        }
    }
}
