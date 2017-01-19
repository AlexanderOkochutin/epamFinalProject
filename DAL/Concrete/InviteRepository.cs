using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interface;
using DAL.Interface.DTO;
using ORM;
using ORM.Entities;

namespace DAL.Concrete
{
    public class InviteRepository : IInviteRepository
    {

        public readonly SocialNetworkContext context;
        private readonly DbSet<FriendInvite> Invites;
        private readonly DbSet<Profile> Profiles;

        public InviteRepository(SocialNetworkContext socialNetworkContext)
        {
            context = socialNetworkContext;
            Invites = socialNetworkContext.Invites;
            Profiles = socialNetworkContext.Profiles;
        }
        public void Create(DalInvite entity)
        {
            var invite = new FriendInvite()
            {
              Id = entity.Id,
              Response = entity.Response
            };
            var profileFrom = Profiles.FirstOrDefault(p=>p.Id==entity.IdFrom);
            var profileTo = Profiles.FirstOrDefault(p => p.Id == entity.IdTo);
            invite.FromProfile = profileFrom;
            invite.ToProfile = profileTo;
            Invites.Add(invite);
        }

        public void Delete(int id)
        {
            Invites.Remove(Invites.FirstOrDefault(i => i.Id == id));
        }

        public DalInvite Get(int id)
        {
            var invite =  Invites.FirstOrDefault(i => i.Id == id);
            DalInvite result = new DalInvite()
            {
                Id = invite.Id,
                Response = invite.Response,
                IdFrom = invite.FromProfile.Id,
                IdTo = invite.ToProfile.Id
            };
            return result;
        }

        public IEnumerable<DalInvite> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalInvite GetByPredicate(Expression<Func<DalInvite, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Update(DalInvite entity)
        {
            throw new NotImplementedException();
        }
    }
}