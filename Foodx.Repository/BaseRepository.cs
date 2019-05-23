using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Foodx.Repository
{
    public class ConnectMongoDB
    {
        public IMongoDatabase db;
        public void Connect(string ConnectionString)
        {
            try
            {
                MongoClient client = new MongoClient(ConnectionString);
                db = client.GetDatabase("dbfoodx");
            }
            catch (MongoException ex)
            {
                throw new System.Exception(ex.Message);
            }
        }
    }
}