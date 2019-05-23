using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Foodx.Business;
using Foodx.Repository.Entity;
using Foodx.Repository.Interface;

namespace Foodx.Api.Controllers
{
    [Route("api/[controller]")]
    public class RestaurantController : Controller
    {
        RestaurantBusiness restaurantBusiness = null;
        public RestaurantController(IRestaurant restaurantRepository)
        {
            restaurantBusiness = new RestaurantBusiness(restaurantRepository);
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };

            var listRestaurant = restaurantBusiness.Get();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";

            var listRestaurant = restaurantBusiness.Get(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            RestaurantEntity model = new RestaurantEntity();

            model.IdRestaurant = 3;
            model.NmRestaurant = "Restaurante 3";

            restaurantBusiness.Create(model);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            restaurantBusiness.Remove(id);
        }
    }
}
