using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class TrackModel
    {
        public long Id { get; set; }
        public TrackDetailModel TrackDetail { get; set; }
        public string Title { get; set; }
        public long ArtistId { get; set; }
        public ArtistModel Artist { get; set; }
        public long AlbumId { get; set; }
        public AlbumModel Album { get; set; }
        public long CategoryId { get; set; }
        public CategoryModel Category { get; set; }
        public ICollection<PlaylistTrackModel> PlaylistTracks { get; set; }
        

    }
}
