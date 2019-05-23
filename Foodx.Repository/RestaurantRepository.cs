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
        private readonly IMongoCollection<RestaurantEntity> _restaurant;

        public RestaurantRepository(IConfiguration config)
        {
            base.Connect(config.GetConnectionString("dbfoodx"));
            _restaurant = db.GetCollection<RestaurantEntity>("Restaurant");
        }

        public IEnumerable<RestaurantEntity> Get()
        {
            return _restaurant.Find<RestaurantEntity>(Restaurant => true).ToList();
        }

        public RestaurantEntity Get(int id)
        {
            return _restaurant.Find<RestaurantEntity>(restaurant => restaurant.IdRestaurant == id).FirstOrDefault();
        }

        public void Create(RestaurantEntity restaurant)
        {
            _restaurant.InsertOne(restaurant);
        }

        public void Update(int id, RestaurantEntity restaurantIn)
        {
            _restaurant.ReplaceOne(restaurant => restaurant.IdRestaurant == id, restaurantIn);
        }

        public void Remove(RestaurantEntity restaurantIn)
        {
            _restaurant.DeleteOne(restaurant => restaurant == restaurantIn);
        }

        public void Remove(int id)
        {
            _restaurant.DeleteOne(restaurant => restaurant.IdRestaurant == id);
        }
    }
}

