using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class CategoryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<AlbumModel> Albums { get; set; }
        public ICollection<ArtistModel> Artists { get; set; }
        public ICollection<TrackModel> Tracks { get; set; }

    }
}
