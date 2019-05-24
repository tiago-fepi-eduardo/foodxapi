using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Foodx.Repository
{
    public class ConnectMongoDB
    {
        public IMongoDatabase _database;
        public void Connect(IConfiguration configuration)
        {
            try
            {
                 var client = new MongoClient(configuration.GetSection("MongoConnection:ConnectionString").Value);
                 if (client != null)
                    _database = client.GetDatabase(configuration.GetSection("MongoConnection:Database").Value);
            }
            catch (MongoException ex)
            {
                throw new System.Exception(ex.Message);
            }
        }
    }
}