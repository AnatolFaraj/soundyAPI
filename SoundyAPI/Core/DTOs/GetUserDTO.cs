using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class GetUserDTO
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public UserType UserType { get; set; }
        public DateTime? LastLoginDate { get; set; }
    }
}
