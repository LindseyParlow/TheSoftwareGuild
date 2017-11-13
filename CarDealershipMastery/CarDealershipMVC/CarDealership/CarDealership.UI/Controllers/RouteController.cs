using CarDealership.Data;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CarDealership.UI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RouteController : ApiController
    {
        [Route("inventory/new/all")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetTop20NewVehicles()
        {
            List<Vehicle> vehicles = DealershipRepositoryFactory.Create().GetTop20NewVehicles();

            if (vehicles == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(vehicles);
            }
        }

        [Route("inventory/used/all")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetTop20UsedVehicles()
        {
            List<Vehicle> vehicles = DealershipRepositoryFactory.Create().GetTop20UsedVehicles();

            if (vehicles == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(vehicles);
            }
        }

        [Route("home/featured")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetTop20FeaturedVehicles()
        {
            List<Vehicle> vehicles = DealershipRepositoryFactory.Create().GetAllFeaturedVehicles();

            if (vehicles == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(vehicles);
            }
        }

        [Route("home/specials")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllSpecials()
        {
            List<Special> specials = DealershipRepositoryFactory.Create().GetAllSpecials();

            if (specials == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(specials);
            }
        }
    }
}

