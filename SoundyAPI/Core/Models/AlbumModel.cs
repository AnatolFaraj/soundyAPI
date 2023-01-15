using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class AlbumModel
    {
        public long Id { get; set; }
        public long ArtistId { get; set; }
        public ArtistModel Artist { get; set; }
        public long CategoryId { get; set; }
        public CategoryModel Category { get; set; }
        public string Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public long Listenings { get; set; }
        public string Picture { get; set; }
        public ICollection<UserAlbumModel> UserAlbums { get; set; }
        public ICollection<TrackModel> Tracks { get; set; }


    }
}
