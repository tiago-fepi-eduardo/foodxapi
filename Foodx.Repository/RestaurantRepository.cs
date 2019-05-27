using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Foodx.Repository.Entity;
using Foodx.Repository.Interface;

namespace Foodx.Repository
{
    public class RestaurantRepository : ConnectMongoDB, IRestaurant
    {
        IMongoCollection<RestaurantEntity> _table;
        public RestaurantRepository(IConfiguration configuration)
        {
            base.Connect(configuration);
            _table = _database.GetCollection<RestaurantEntity>("restaurant");
        }

        public IEnumerable<RestaurantEntity> Get()
        {
            return _table.Find<RestaurantEntity>(Restaurant => true).ToList();
        }

        public RestaurantEntity Get(int id)
        {
            return _table.Find<RestaurantEntity>(restaurant => restaurant.IdRestaurant == id).FirstOrDefault();
        }

        public void Create(RestaurantEntity restaurant)
        {
            _table.InsertOne(restaurant);
        }

        public void Update(int id, RestaurantEntity restaurantIn)
        {
            _table.ReplaceOne(restaurant => restaurant.IdRestaurant == id, restaurantIn);
        }

        public void Remove(RestaurantEntity restaurantIn)
        {
            _table.DeleteOne(restaurant => restaurant == restaurantIn);
        }

        public void Remove(int id)
        {
            _table.DeleteOne(restaurant => restaurant.IdRestaurant == id);
        }
    }
}

