using JAC.MusicVideoList.Domain.Core.Interfaces;
using JAC.MusicVideoList.Infrastructure.Main.Data.ContextMongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAC.MusicVideoList.Infrastructure.Main.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserContext _context;
        private readonly IUserRepository _userRepository;

        public UnitOfWork(UserContext context)
        {
            _context = context;
        }
        public IUserRepository UserRepository => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
