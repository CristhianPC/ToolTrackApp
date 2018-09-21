using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolTrackApp.Model.Entities.ToolTrackAppDB
{
    [Table(Name = "dbo.Parts")]
    public partial class Part
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        [Column]
        public string Name { get; set; }
        [Column]
        public int Code { get; set; }
        [Column]
        public bool IsUsed { get; set; }
        [Column]
        public int UserCreationId { get; set; }
        [Column]
        public int Amount { get; set; }
        [Column]
        public string Image { get; set; }
        [Column]
        public string Description { get; set; }
        [Column]
        public int ProviderId { get; set; }
        [Column]
        public string QRCode { get; set; }
        [Column]
        public int UnitPrice { get; set; }
        [Column]
        public DateTime CreationDate { get; set; }

    }
}
