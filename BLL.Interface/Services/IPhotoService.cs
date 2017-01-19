using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IPhotoService
    {
        void AddPhoto(BllPhoto photo);
        void AddAvatarToUser(BllPhoto photo, string email);
        void DeletePhoto(BllPhoto photo);
        void UpdatePhoto(BllPhoto photo);
        List<BllPhoto> GetAllPhotos(int userId);
        BllPhoto GetPhoto(int key);
    }
}
