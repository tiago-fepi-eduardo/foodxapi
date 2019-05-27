using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;

namespace Foodx.Model
{
    public class RestaurantModel : BaseModel
    {
        public RestaurantModel()
        {
            ListRestaurant = new List<RestaurantModel>();
        }

        public ObjectId _id { get; set; }
        public int IdRestaurant { get; set; }
        public string NmRestaurant { get; set; }
        public List<RestaurantModel> ListRestaurant{ get; set; }
    }
}