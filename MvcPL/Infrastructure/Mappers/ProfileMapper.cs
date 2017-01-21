using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interface.Entities;
using DAL.Interface.DTO;
using MvcPL.ViewModels;

namespace MvcPL.Infrastructure.Mappers
{

    public static class ProfileMapper
    {
        /// <summary>
        /// Map User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>new BllUser same as user</returns>
        public static ProfileModel ToViewProfileModel(this BllProfile profile)
        {
            if (ReferenceEquals(profile, null)) return null;
            ProfileModel result = new ProfileModel()
            {
                Id = profile.Id,
                LastName = profile.LastName,
                BirthDay = profile.BirthDay,
                Gender = profile.Gender,
                RelationStatus = profile.RelationStatus,
                FirstName = profile.FirstName,
                AvatarId = profile.AvatarId,
                City = profile.City,
                Friends = profile.Friends,
                IsNewInvite = profile.IsNewInvites
            };
            return result;
        }

        /// <summary>
        /// Map User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>new DalUser same as user</returns>
        public static BllProfile ToBllProfile(this ProfileModel profile)
        {
            if (ReferenceEquals(profile, null)) return null;
            BllProfile result = new BllProfile()
            {
                Id = profile.Id,
                LastName = profile.LastName,
                BirthDay = profile.BirthDay,
                Gender = profile.Gender,
                RelationStatus = profile.RelationStatus,
                FirstName = profile.FirstName,
                AvatarId = profile.AvatarId,
                City = profile.City,
                Friends = profile.Friends,
                IsNewInvites = profile.IsNewInvite
            };
            return result;
        }

        /// <summary>
        /// Map Users
        /// </summary>
        /// <param name="users"></param>
        /// <returns>new BllUsers collection same as users</returns>
        public static IEnumerable<ProfileModel> Map(IEnumerable<BllProfile> profiles)
        {
            var Profiles = new List<ProfileModel>();
            foreach (var item in profiles)
            {
               Profiles.Add(item.ToViewProfileModel());
            }
            return Profiles;
        }
    }
}