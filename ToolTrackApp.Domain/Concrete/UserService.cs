using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolTrackApp.Domain.Base;
using ToolTrackApp.Domain.Interfaces;
using ToolTrackApp.Model.Entities.ToolTrackAppDB;
using ToolTrackApp.Model.SqlRepository.DAO;

namespace ToolTrackApp.Domain.Concrete
{
    public class UserService : BaseService, IUserService
    {
        private UserDAO UserDAO = null;
        public UserService()
        {
            this.UserDAO = new UserDAO();
        }

        public IList<User> GetUsers()
        {
            return this.Db.GetRepository<User>().SelectByFilter(u => u.IsActive);
        }
    }

    

    
    }
}
