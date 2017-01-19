using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class ProfileMapper
    {
        /// <summary>
        /// Map User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>new BllUser same as user</returns>
        public static BllProfile ToBllProfile(this DalProfile profile)
        {
            if (ReferenceEquals(profile, null)) return null;
            BllProfile result = new BllProfile()
            {
              Id = profile.Id,
              LastName = profile.LastName,
              BirthDay = profile.BirthDay,
              Gender = profile.Gender,
              RelationStatus = profile.RelationStatus,
              FirstName = profile.FirstName
            };
            return result;
        }

        /// <summary>
        /// Map User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>new DalUser same as user</returns>
        public static DalProfile ToDalProfile(this BllProfile profile)
        {
            if (ReferenceEquals(profile, null)) return null;
            DalProfile result = new DalProfile()
            {
                Id = profile.Id,
                LastName = profile.LastName,
                BirthDay = profile.BirthDay,
                Gender = profile.Gender,
                RelationStatus = profile.RelationStatus,
                FirstName = profile.FirstName
            };
            return result;
        }

        /// <summary>
        /// Map Users
        /// </summary>
        /// <param name="users"></param>
        /// <returns>new BllUsers collection same as users</returns>
        public static IEnumerable<BllProfile> Map(IEnumerable<DalProfile> profiles)
        {
            var bllProfiles = new List<BllProfile>();
            foreach (var item in profiles)
            {
                bllProfiles.Add(item.ToBllProfile());
            }
            return bllProfiles;
        }
    }

}
