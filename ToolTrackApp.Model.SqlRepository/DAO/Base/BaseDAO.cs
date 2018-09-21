using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolTrackApp.Model.SqlRepository.Context;

namespace ToolTrackApp.Model.SqlRepository.DAO.Base
{
    public class BaseDAO
    {
        internal ToolTrackContext db;
        public BaseDAO()
        {
            db = new ToolTrackContext();
        }
    }
}
