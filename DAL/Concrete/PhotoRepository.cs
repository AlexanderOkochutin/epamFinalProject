using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using DAL.Interface.DTO;
using DAL.Mappers;
using ORM;
using ORM.Entities;

namespace DAL.Concrete
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly SocialNetworkContext context;
        private readonly DbSet<Photo> Photos;
        private readonly DbSet<Profile> Profiles;

        public PhotoRepository(SocialNetworkContext socialNetworkContext)
        {
            context = socialNetworkContext;
            Photos = socialNetworkContext.Set<Photo>();
            Profiles = socialNetworkContext.Set<Profile>();
        }

        public void Create(DalPhoto dalPhoto)
        {
            var photo = dalPhoto.ToPhoto();
            foreach (var profileId in dalPhoto.ProfileId)
            {
                var profile = Profiles.FirstOrDefault(p => p.Id == profileId);
                photo.Profile.Add(profile);
            }
            Photos.Add(photo);
        }

        public void Delete(int id)
        {
            Photos.Remove(Photos.FirstOrDefault(p => p.Id == id));
        }

        public DalPhoto Get(int id)
        {
            return Photos.FirstOrDefault(p => p.Id == id).ToDalPhoto();
        }

        public IEnumerable<DalPhoto> GetAll()
        {
            return Photos.Include(p => p.Profile).Select(p => p).Map();
        }

        public DalPhoto GetByPredicate(Expression<Func<DalPhoto, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Update(DalPhoto dalPhoto)
        {
            var photo = Photos.FirstOrDefault(p => p.Id == dalPhoto.Id);
            if (!ReferenceEquals(photo, null))
            {
                photo.Data = dalPhoto.Data;
                photo.Date = dalPhoto.Date;
                photo.MimeType = dalPhoto.MimeType;
                photo.Profile.Clear();
                foreach (var item in dalPhoto.ProfileId)
                {
                    var profile = Profiles.FirstOrDefault(p => p.Id == item);
                    photo.Profile.Add(profile);
                }
                context.Entry(photo).State = EntityState.Modified;
            }
        }
    }
}
