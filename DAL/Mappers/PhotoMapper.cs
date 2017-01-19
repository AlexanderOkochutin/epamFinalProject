using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using ORM.Entities;

namespace DAL.Mappers
{
    /// <summary>
    /// Service class for mapping DalUser and ORM User entities
    /// </summary>
    public static class PhotoMapper
    {
        /// <summary>
        /// Map User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>new ORM User entity same as user</returns>
        public static Photo ToPhoto(this DalPhoto photo)
        {
            if (ReferenceEquals(photo, null)) return null;
            Photo result = new Photo()
            {
                Id = photo.Id,
                Data = photo.Data,
                Date = photo.Date,
                MimeType = photo.MimeType,
                IsAvatar = photo.IsAvatar
            };

            return result;
        }

        /// <summary>
        /// Map User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>new DalUser entity same as user</returns>
        public static DalPhoto ToDalPhoto(this Photo photo)
        {
            if (ReferenceEquals(photo, null)) return null;
            DalPhoto result = new DalPhoto()
            {
                Id = photo.Id,
                Date = photo.Date,
                Data = photo.Data,
                MimeType = photo.MimeType,
                IsAvatar = photo.IsAvatar
            };
            foreach (var profile in photo.Profile)
            {
                result.ProfileId.Add(profile.Id);
            }
            return result;
        }

        /// <summary>
        /// Map users
        /// </summary>
        /// <param name="users"></param>
        /// <returns>new DalUser collection same as users</returns>
        public static IEnumerable<DalPhoto> Map(this IQueryable<Photo> photos)
        {
            var dalPhotos = new List<DalPhoto>();
            foreach (var item in photos)
            {
                dalPhotos.Add(item.ToDalPhoto());
            }
            return dalPhotos;
        }
    }
}
