using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Foodx.Business;
using Foodx.Repository.Entity;
using Microsoft.Extensions.Configuration;
using Foodx.Model;

namespace Foodx.Api.Controllers
{
    [Route("api/[controller]")]
    public class RestaurantController : Controller
    {
        RestaurantBusiness restaurantBusiness = null;
        public RestaurantController(IConfiguration configuration)
        {
            restaurantBusiness = new RestaurantBusiness(configuration);
        }

        // GET api/restaurant
        [HttpGet]
        public RestaurantModel Get()
        {
            RestaurantModel model = new RestaurantModel();

            try
            {
                var listResult = restaurantBusiness.Get();
                foreach (var item in listResult)
                {
                    model.ListRestaurant.Add(new RestaurantModel()
                    {
                        _id = item._id,
                        IdRestaurant = item.IdRestaurant,
                        NmRestaurant = item.NmRestaurant
                    });
                    model.ErrorSuccess = true;
                }
            }
            catch (Exception ex)
            {
                model.ErrorSuccess = false;
                model.ErrorNmMessage = ex.Message;
            }
            return model;
        }

        // GET api/restaurant/5
        [HttpGet("{id}")]
        public RestaurantModel Get(int id)
        {
            RestaurantModel model = new RestaurantModel();

            try
            {
                var result = restaurantBusiness.Get(id);

                model.IdRestaurant = result.IdRestaurant;
                model.NmRestaurant = result.NmRestaurant;
                model.ErrorSuccess = true;
            }
            catch (Exception ex)
            {
                model.ErrorSuccess = false;
                model.ErrorNmMessage = ex.Message;
            }
            return model;
        }

        // GET api/restaurant/getcount
        //[HttpGet]
        //public int GetCount()
        //{
        //    return restaurantBusiness.Get().Count();
        //}

        // POST api/restaurant
        [HttpPost]
        public RestaurantModel Post([FromForm]int restaurantId, string restaurantName)
        {
            RestaurantModel model = new RestaurantModel();
            try
            {
                RestaurantEntity entity = new RestaurantEntity();
                entity.IdRestaurant = restaurantId;
                entity.NmRestaurant = restaurantName;
                restaurantBusiness.Create(entity);
                model.ErrorSuccess = true;
            }
            catch (Exception ex)
            {
                model.ErrorSuccess = false;
                model.ErrorNmMessage = ex.Message;
            }
            return model;
        }

        // DELETE api/restaurant/5
        [HttpDelete("{id}")]
        public RestaurantModel Delete(int id)
        {
            RestaurantModel model = new RestaurantModel();
            try
            {
                restaurantBusiness.Remove(id);
                model.ErrorSuccess = true;
            }
            catch (Exception ex)
            {
                model.ErrorSuccess = false;
                model.ErrorNmMessage = ex.Message;
            }
            return model;
        }
    }
}
