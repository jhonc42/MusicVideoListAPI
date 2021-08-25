using JAC.MusicVideoList.Domain.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAC.MusicVideoList.Domain.Core.Entities
{
    public class MongoSettings : IMongoSettings
    {
        public string ConnectionString { get; set; }
        public string DataBase { get; set; }
    }
}
