using JAC.MusicVideoList.Domain.Core.Entities;
using JAC.MusicVideoList.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAC.MusicVideoList.Infrastructure.Main.Services
{
    public class SecurityService : ISecurityService
    {
        public async Task RegisterSecurityUser(SecurityUser securityUser)
        {
            var user = securityUser;
            // TODO implement UnitOfWork and DB connection, what DB are you gonna use?
        }
    }
}
