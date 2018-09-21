using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToolTrackApp.Models.User
{
    public class UserDataViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RoleId { get; set; }
        public DateTime CreationDate { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}