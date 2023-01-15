using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class PlaylistModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public UserModel User { get; set; }
        public string Name { get; set; }
        public PlaylistType Type { get; set; }
        public ICollection<PlaylistTrackModel> PlaylistTracks { get; set; }
    }
}
