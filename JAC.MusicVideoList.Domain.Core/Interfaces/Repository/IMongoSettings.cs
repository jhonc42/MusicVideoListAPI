using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAC.MusicVideoList.Domain.Core.Interfaces.Repository
{
    public interface IMongoSettings
    {
        string ConnectionString { get; set; }
        string DataBase { get; set; }
    }
}
