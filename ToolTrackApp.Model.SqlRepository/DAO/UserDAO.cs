using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolTrackApp.Model.Entities.ToolTrackAppDB;
using ToolTrackApp.Model.SqlRepository.DAO.Base;

namespace ToolTrackApp.Model.SqlRepository.DAO
{
    public class UserDAO : BaseDAO
    {
        //public List<User> GetUsers()
        //{
        //    var user = (from u in db.Users
        //                join ro in db.Roles on u.RoleId equals ro.Id
        //                select new
        //                {
        //                    Name = u.Name + " " + ro.Name,
        //                    PhoneNumber = u.PhoneNumber
        //                }).ToList();
        //    var listUser = new List<User>();
        //    user.ForEach(d => listUser.Add(new User { Name = d.Name, PhoneNumber = d.PhoneNumber }));
        //    return listUser;
        //}
    }
}
