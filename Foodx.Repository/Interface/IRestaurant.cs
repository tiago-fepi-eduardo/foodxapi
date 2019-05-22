using System;
using System.Collections.Generic;
using Foodx.Repository.Entity;

namespace Foodx.Repository.Interface
{
    public interface IRestaurant
    {
        void Create(RestaurantEntity restaurant);
        
        void Update(int id, RestaurantEntity restaurant);

        RestaurantEntity Get(int id);
        
        IEnumerable<RestaurantEntity> Get();
        
        void Remove(RestaurantEntity restaurant);

        void Remove(int id);
    } 
}