using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface;

namespace BLL.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IUnitOfWork uow;


        public PhotoService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void AddAvatarToUser(BllPhoto photo, string email)
        {
            throw new NotImplementedException();
        }

        public void AddPhoto(BllPhoto photo)
        {
            uow.Photos.Create(photo.ToDalPhoto());
            uow.Commit();
        }

        public void DeletePhoto(BllPhoto photo)
        {
            uow.Photos.Delete(photo.Id);
        }

        public List<BllPhoto> GetAllPhotos(int userId)
        {
            List<BllPhoto> photos = new List<BllPhoto>();
            var profilePhotos = uow.Photos.GetAll();
            foreach (var photo in profilePhotos)
            {
                foreach (var profileId in photo.ProfileId)
                {
                    if (profileId == userId)
                    {
                        photos.Add(photo.ToBllPhoto());
                    }
                }
            }
            return photos;
        }

        public BllPhoto GetPhoto(int key)
        {
            return uow.Photos.Get(key).ToBllPhoto();
        }

        public void UpdatePhoto(BllPhoto photo)
        {
            uow.Photos.Update(photo.ToDalPhoto());
            uow.Commit();
        }
    }
}
