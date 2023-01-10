using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class UserModel
    {
        public long Id { get; set; }
        public CredentialsModel Credential { get; set; }
        public string Name { get; set; }
        public UserType UserType { get; set; }
        public ICollection<PlaylistModel> Playlists { get; set; }
        public ICollection<ArtistModel> Artists { get; set; }
        public ICollection<AlbumModel> Albums { get; set; }
    }
}
