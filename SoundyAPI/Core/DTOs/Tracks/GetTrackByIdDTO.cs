using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Tracks
{
    public class GetTrackByIdDTO
    {
        public string Title { get; set; }
        public string ArtistName { get; set; }
        public string AlbumName { get; set; }
        public string CategoryName { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Picture { get; set; }
        public string TrackFile { get; set; }

    }
}
