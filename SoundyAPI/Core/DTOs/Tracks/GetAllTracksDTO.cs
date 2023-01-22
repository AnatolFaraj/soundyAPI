using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Tracks
{
    public class GetAllTracksDTO
    {
        public List<GetTrackByIdDTO> AllTracks { get; set; }
    }
}
