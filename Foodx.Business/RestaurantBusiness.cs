using System.Collections.Generic;
using System.Linq;
using Foodx.Repository.Interface;
using Foodx.Repository;
using Foodx.Repository.Entity;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;

namespace Foodx.Business
{
    public class RestaurantBusiness
    {
       private readonly RestaurantRepository _restaurant;

        public RestaurantBusiness(IConfiguration configuration)
        {
            _restaurant = new RestaurantRepository(configuration);
        }

        public void Create(RestaurantEntity restaurant){
           _restaurant.Create(restaurant);
        }

        public RestaurantEntity Get(int id){
            return _restaurant.Get(id);
        }
    
        public IEnumerable<RestaurantEntity> Get(){
               return  _restaurant.Get();
        }

         public void Remove(int id){
             _restaurant.Remove(id);
        }
    }
}