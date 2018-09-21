using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolTrackApp.Model.Entities.ToolTrackAppDB
{
    [Table(Name = "dbo.Location")]
    public class Location
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        [Column]
        public string Name { get; set; }
        [Column]
        public string Address { get; set; }
        [Column]
        public DateTime CreationDate { get; set; }
        [Column]
        public string CreationUser { get; set; }
    }
}
