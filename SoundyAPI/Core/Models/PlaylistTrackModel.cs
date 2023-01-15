using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class PlaylistTrackModel
    {
        public long PlaylistId { get; set; }
        public PlaylistModel Playlist { get; set; }
        public long TrackId { get; set; }
        public TrackModel Track { get; set; }
    }
}
