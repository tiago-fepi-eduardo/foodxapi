using System.Collections.Generic;
using System.Linq;
using Foodx.Repository.Interface;
using Foodx.Repository;
using Foodx.Repository.Entity;

namespace Foodx.Business
{
    public class RestaurantBusiness
    {
       private readonly IRestaurant _restaurant;

        public RestaurantBusiness()
        {
            _restaurant = new RestaurantRepository();
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