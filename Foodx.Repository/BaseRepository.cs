using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Foodx.Repository
{
    public class ConnectMongoDB
    {
        public IMongoDatabase _database;
        public void Connect(IOptions<SettingsVO> settings)
        {
            try
            {
                 var client = new MongoClient(settings.Value.ConnectionString);
                 if (client != null)
                    _database = client.GetDatabase(settings.Value.Database);
            }
            catch (MongoException ex)
            {
                throw new System.Exception(ex.Message);
            }
        }
    }
     public class SettingsVO
    {
        public string ConnectionString;
        public string Database;
    }
}