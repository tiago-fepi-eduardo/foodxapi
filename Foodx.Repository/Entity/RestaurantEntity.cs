using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;

namespace Foodx.Repository.Entity
{
    public class RestaurantEntity
    {
        public ObjectId _id { get; set; }
        public int IdRestaurant { get; set; }
        public string NmRestaurant { get; set; }
    }
}