using Core.DTOs.Tracks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Albums
{
    public class GetAlbumByIdDTO
    {
        public string Name { get; set; }
        public string ArtistName { get; set; }
        public string CategoryName { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public long TotalListenings { get; set; }
        public string Picture { get; set; }
        public List<AlbumTrackDTO> Tracks { get; set; }
    }
}
