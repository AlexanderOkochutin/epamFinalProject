using System;
using System.Collections.Generic;
using System.Configuration;
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
    public class ProfileRepository : IProfileRepository
    {
        private readonly SocialNetworkContext context;
        private readonly DbSet<Profile> Profiles;
        private readonly DbSet<Message> Messages;
        private readonly DbSet<Photo> Photos;
        private readonly DbSet<User> Users;


        public ProfileRepository(SocialNetworkContext socialNetworkContext)
        {
            context = socialNetworkContext;
            Profiles = socialNetworkContext.Set<Profile>();
            Messages = socialNetworkContext.Set<Message>();
            Photos = socialNetworkContext.Set<Photo>();
        }

        public void Create(DalProfile dalProfile)
        {
            var profile = dalProfile.ToProfile();
            /*
            var messages = Messages.Select(m => m).Where(m => m.ProfileFrom.Id == dalProfile.Id);
            var photos = Profiles.FirstOrDefault(p => p.Id == dalProfile.Id).Photos;
            foreach (var message in messages)
            {
                profile.Messages.Add(message);
            }
            foreach (var photo in photos)
            {
                profile.Photos.Add(photo);
            }
            */
            Profiles.Add(profile);
        }

        public void Delete(int id)
        {
            Profiles.Remove(Profiles.FirstOrDefault(p => p.Id == id));
        }

        public DalProfile Get(int id)
        {
            return Profiles.FirstOrDefault(p => p.Id == id).ToDalProfile();
        }

        public IEnumerable<DalProfile> GetAll()
        {
            return
                Profiles.Include(p => p.Photos)
                    .Include(p => p.Messages)
                    .Include(p => p.Friends)
                    .Include(p => p.InFriends)
                    .Select(p => p)
                    .Map();
        }

        public DalProfile GetByPredicate(Expression<Func<DalProfile, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Update(DalProfile dalProfile)
        {
            var profile = Profiles.FirstOrDefault(p=>p.Id==dalProfile.Id);
            if (!ReferenceEquals(profile, null))
            {
                profile.BirthDay = dalProfile.BirthDay;
                profile.FirstName = dalProfile.FirstName;
                profile.LastName = dalProfile.LastName;
                profile.Gender = dalProfile.Gender;
                profile.RelationStatus = dalProfile.RelationStatus;
                profile.AvatarId = dalProfile.AvatarId;
                profile.IsNewInvites = dalProfile.IsNewInvites;
                profile.City = dalProfile.City;
            }
            foreach (var id in dalProfile.Friends)
            {
                var temp = Profiles.FirstOrDefault(p=>p.Id==id);
                profile.Friends.Add(temp);
            }
            context.Entry(profile).State = EntityState.Modified;
        }
    }
}
