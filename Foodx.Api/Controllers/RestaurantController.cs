using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Foodx.Business;
using Foodx.Repository.Entity;

namespace Foodx.Api.Controllers
{
    [Route("api/[controller]")]
    public class RestaurantController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };

            RestaurantBusiness restaurantBusiness = new RestaurantBusiness();
            var listRestaurant = restaurantBusiness.Get();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";

            RestaurantBusiness restaurantBusiness = new RestaurantBusiness();
            var listRestaurant = restaurantBusiness.Get(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            RestaurantBusiness restaurantBusiness = new RestaurantBusiness();
            RestaurantEntity model = new RestaurantEntity();

            model.IdRestaurant = 3;
            model.NmRestaurant = "Restaurante 3";

            restaurantBusiness.Create(model);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            RestaurantBusiness restaurantBusiness = new RestaurantBusiness();
            restaurantBusiness.Remove(id);
        }
    }
}
