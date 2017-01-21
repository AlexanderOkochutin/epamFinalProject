using DAL.Interface.DTO;

namespace DAL.Interface
{
    public interface IInviteRepository:IRepository<DalInvite>
    {
        DalInvite GetConcreteInvite(int idFrom, int idTo);
    }
}