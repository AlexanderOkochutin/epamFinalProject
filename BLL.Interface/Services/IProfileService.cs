using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using DAL.Interface;
using DAL.Interface.DTO;

namespace BLL.Interface.Services
{
    public interface IProfileService
    {
        BllProfile Get(int id);
        void Update(BllProfile profile);
        void SendRequest(int idFrom, int idTo);
        void AddFriend(int userId,int friendId );
    }
}
