using JAC.MusicVideoList.Domain.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAC.MusicVideoList.Infrastructure.Main.Data.ContextMongoDB
{
    public interface IUserContext
    {
        IMongoCollection<User> Users {get;}
    }
}
