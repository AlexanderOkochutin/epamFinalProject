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

        public void AddFriend(int userId,int friendId)
        {
            var user = uow.Profiles.Get(userId);
            var friend = uow.Profiles.Get(friendId);
            user.Friends.Add(friendId);
            friend.Friends.Add(userId);
            uow.Profiles.Update(user);
            uow.Profiles.Update(friend);
            uow.Commit();
        }
    }
}
