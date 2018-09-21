using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolTrackApp.Model.Entities.ToolTrackApp
{

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RoleId { get; set; }
        public DateTime CreationDate { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsActive{ get; set; }
    }
}
