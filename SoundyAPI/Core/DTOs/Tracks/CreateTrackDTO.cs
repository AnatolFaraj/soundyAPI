using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Tracks
{
    public class CreateTrackDTO
    {
        public string Title { get; set; }

        public long AlbumId { get; set; }

        public string TrackFile { get; set; }




    }
}
