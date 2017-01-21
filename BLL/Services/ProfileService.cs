using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface;
using DAL.Interface.DTO;

namespace BLL.Services
{
    public class ProfileService:IProfileService
    {
        private readonly IUnitOfWork uow;

        public ProfileService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public BllProfile Get(int id)
        {
            return uow.Profiles.Get(id).ToBllProfile();
        }

        public void Update(BllProfile profile)
        {
            uow.Profiles.Update(profile.ToDalProfile());
            uow.Commit();
        }

        public void SendRequest(int idFrom,int idTo)
        {
           DalInvite invite = new DalInvite()
           {
                IdFrom = idFrom,
                IdTo = idTo,
                Response = null
           };
            uow.Invites.Create(invite);
            var profileTo = uow.Profiles.Get(idTo);
            profileTo.IsNewInvites = true;
            uow.Profiles.Update(profileTo);
            uow.Commit();
        }

        public IList<BllProfile> GetAllRequests(int id)
        {
            var invites = uow.Invites.GetAll().Where(i=>i.IdTo==id).Select(i=>i);
            IList<BllProfile> result = new List<BllProfile>();
            foreach (var invite in invites)
            {
                var profile = uow.Profiles.Get(invite.IdFrom);
                result.Add(profile.ToBllProfile());
            }
            return result;
        }

        public void AddFriend(int userId,int friendId)
        {
            var user = uow.Profiles.Get(userId);
            var friend = uow.Profiles.Get(friendId);
            var invite = uow.Invites.GetConcreteInvite(friendId, userId);
            uow.Invites.Delete(invite.Id);
            user.Friends.Add(friendId);
            friend.Friends.Add(userId);
            uow.Profiles.Update(user);
            uow.Profiles.Update(friend);
            uow.Commit();
        }

        /// <summary>
        /// The method for profile searching
        /// </summary>
        /// <param name="stringKey"></param>
        /// <param name="city"></param>
        /// <returns></returns>
        public IEnumerable<BllProfile> Find(string stringKey = "", string city = null)
        {
            var profiles = uow.Profiles.GetAll();
            if (!ReferenceEquals(stringKey, null)) profiles = profiles.Where(p => (p.FirstName + " " + p.LastName).Contains(stringKey));
            if (!ReferenceEquals(city, null)) profiles = profiles.Where(p => p.City != null && p.City.Contains(city));

            return ProfileMapper.Map(profiles);
        }
    }
}
