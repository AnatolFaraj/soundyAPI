using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class TrackDetailModel
    {
        public long TrackId { get; set; }
        public TrackModel Track { get; set; }
        public DateTime? ReleaseDate { get; set; }

        public string Picture { get; set; }
    }
}
