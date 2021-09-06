using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JAC.MusicVideoList.Domain.Core.Enums;

namespace JAC.MusicVideoList.Application.Main.DTOs
{
    public class UserTokenDTO
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }

        public RoleType Role { get; set; }
    }
}
