using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class PhotoMapper
    {
        /// <summary>
        /// Map User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>new BllUser same as user</returns>
        public static BllPhoto ToBllPhoto(this DalPhoto photo)
        {
            if (ReferenceEquals(photo, null)) return null;
            BllPhoto result = new BllPhoto()
            {
               Id = photo.Id,
               Date = photo.Date,
               ProfileId = photo.ProfileId,
               MimeType = photo.MimeType,
               Data = photo.Data
            };
            return result;
        }

        /// <summary>
        /// Map User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>new DalUser same as user</returns>
        public static DalPhoto ToDalPhoto(this BllPhoto photo)
        {
            if (ReferenceEquals(photo, null)) return null;
            DalPhoto result = new DalPhoto()
            {
                Id = photo.Id,
                Date = photo.Date,
                ProfileId = photo.ProfileId,
                MimeType = photo.MimeType,
                Data = photo.Data
            };
            return result;
        }

        /// <summary>
        /// Map Users
        /// </summary>
        /// <param name="users"></param>
        /// <returns>new BllUsers collection same as users</returns>
        public static IEnumerable<BllPhoto> Map(IEnumerable<DalPhoto> photos)
        {
            var bllPhotos = new List<BllPhoto>();
            foreach (var item in photos)
            {
                bllPhotos.Add(item.ToBllPhoto());
            }
            return bllPhotos;
        }
    }
}
