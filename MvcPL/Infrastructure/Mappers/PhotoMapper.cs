using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interface.Entities;
using DAL.Interface.DTO;
using MvcPL.ViewModels;

namespace MvcPL.Infrastructure.Mappers
{
    public static class PhotoMapper
    {
        /// <summary>
        /// Map User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>new BllUser same as user</returns>
        public static PhotoModel ToPhotoModel(this BllPhoto photo)
        {
            if (ReferenceEquals(photo, null)) return null;
            PhotoModel result = new PhotoModel()
            {
                Id = photo.Id,
                Date = photo.Date,
                ProfileId = photo.ProfileId,
                MimeType = photo.MimeType,
                Data = photo.Data,
                IsAvatar = photo.IsAvatar
            };
            return result;
        }

        /// <summary>
        /// Map User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>new DalUser same as user</returns>
        public static BllPhoto ToBllPhoto(this PhotoModel photo)
        {
            if (ReferenceEquals(photo, null)) return null;
            BllPhoto result = new BllPhoto()
            {
                Id = photo.Id,
                Date = photo.Date,
                ProfileId = photo.ProfileId,
                MimeType = photo.MimeType,
                Data = photo.Data,
                IsAvatar = photo.IsAvatar
            };
            return result;
        }

        /// <summary>
        /// Map Users
        /// </summary>
        /// <param name="users"></param>
        /// <returns>new BllUsers collection same as users</returns>
        public static IEnumerable<PhotoModel> Map(IEnumerable<BllPhoto> photos)
        {
            var bllPhotos = new List<PhotoModel>();
            foreach (var item in photos)
            {
                bllPhotos.Add(item.ToPhotoModel());
            }
            return bllPhotos;
        }
    }
}