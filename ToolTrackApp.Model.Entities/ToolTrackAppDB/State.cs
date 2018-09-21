using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolTrackApp.Model.Entities.ToolTrackAppDB
{
    [Table (Name = "dbo.State")]
    public class State
    {
        [Column (IsDbGenerated =true, IsPrimaryKey = true)]
        public int Id { get; set; }
        [Column]
        public string Name { get; set; }
    }
}
