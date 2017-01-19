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

        public void SendFriendRecuest(int idFrom,int idTo)
        {
            
        }
    }
}
