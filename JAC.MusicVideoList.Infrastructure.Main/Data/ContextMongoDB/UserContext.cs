using JAC.MusicVideoList.Domain.Core.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAC.MusicVideoList.Infrastructure.Main.Data.ContextMongoDB
{
    //public class UserContext : IUserContext
    //{
    //    private readonly IMongoDatabase _db;
    //    public UserContext(IOptions<MongoSettings> options)
    //    {
    //        var client = new MongoClient(options.Value.ConnectionString);
    //        _db = client.GetDatabase(options.Value.DataBase);
    //    }
    //    public IMongoCollection<User> Users => _db.GetCollection<User>("User");
    //}
}
