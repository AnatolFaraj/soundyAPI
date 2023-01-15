using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class UserArtistModel
    {
        public long UserId { get; set; }
        public UserModel User { get; set; }
        public long ArtistId { get; set; }
        public ArtistModel Artist { get; set; }
    }
}
