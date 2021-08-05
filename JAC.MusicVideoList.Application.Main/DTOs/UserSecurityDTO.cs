using JAC.MusicVideoList.Application.Main.Enums;

namespace JAC.MusicVideoList.Application.Main.DTOs
{
    public class UserSecurityDTO
    {
        public string User { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public RoleType? Role { get; set; }
    }
}
