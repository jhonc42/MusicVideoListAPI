using JAC.MusicVideoList.Domain.Core.Enums;

namespace JAC.MusicVideoList.Application.Main.DTOs
{
    public class UserDTO

    {
        public string Name { get; set; }

        public string UserName { get; set; }

        // public string Token { get; set; }
        public string Password { get; set; }

        public RoleType? Role { get; set; }
    }
}
