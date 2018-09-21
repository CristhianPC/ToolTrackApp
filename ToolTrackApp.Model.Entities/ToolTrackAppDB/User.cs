using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolTrackApp.Model.Entities.ToolTrackAppDB
{
    [Table(Name = "dbo.User")]
    public class User
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int Id { get; set; }
        [Column]
        public string Name { get; set; }
        [Column]
        public int RoleId { get; set; }
        [Column]
        public DateTime CreationDate { get; set; }
        [Column]
        public int PhoneNumber { get; set; }
        [Column]
        public string Email { get; set; }
        [Column]
        public bool IsActive { get; set; }
    }
}
