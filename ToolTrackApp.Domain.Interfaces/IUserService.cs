using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolTrackApp.Model.Entities.ToolTrackAppDB;

namespace ToolTrackApp.Domain.Interfaces
{
    public interface IUserService
    {
        IList<User> GetUsers();
        //void InsertUser(User user);
        //void DeleteUser(string userId);
        //void UpdateUser(User user);
        //User GetUserById(string userId);
        //User GetUserByName(string userName);
    }
}
