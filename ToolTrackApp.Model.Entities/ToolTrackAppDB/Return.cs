using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolTrackApp.Model.Entities.ToolTrackAppDB
{
    [Table(Name ="dbo.Return")]
    public partial class Return
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        [Column]
        public string Name { get; set; }
        [Column]
        public int PartId { get; set; }
        [Column]
        public int Amount { get; set; }
        [Column]
        public int LocationId { get; set; }
        [Column]
        public int StateId { get; set; }
        [Column]
        public int Code { get; set; }
        [Column]
        public int UserId { get; set; }
        [Column]
        public string Description { get; set; }
    }
}
