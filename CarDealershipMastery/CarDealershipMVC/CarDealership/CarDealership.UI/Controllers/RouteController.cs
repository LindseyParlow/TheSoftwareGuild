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

        [Route("api/home/specials")]
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

        [Route("inventory/new/{input}/{minPrice}/{maxPrice}/{minYear}/{maxYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetSearchNew(string input, int minPrice, int maxPrice, int minYear, int maxYear)
        {
            List<Vehicle> vehicles = DealershipRepositoryFactory.Create().GetNewVehicleByMegaSearchFilter(input, minPrice, maxPrice, minYear, maxYear);

            if (vehicles == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(vehicles);
            }
        }

        [Route("inventory/used/{input}/{minPrice}/{maxPrice}/{minYear}/{maxYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetSearch(string input, int minPrice, int maxPrice, int minYear, int maxYear)
        {
            List<Vehicle> vehicles = DealershipRepositoryFactory.Create().GetUsedVehicleByMegaSearchFilter(input, minPrice, maxPrice, minYear, maxYear);

            if (vehicles == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(vehicles);
            }
        }

        [Route("inventory/details/{vehicleId}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult DetailsByVehicleId(int vehicleId)
        {
            Vehicle vehicle = DealershipRepositoryFactory.Create().GetVehicleDetailsByVehicleId(vehicleId);

            if (vehicle == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(vehicle);
            }
        }

        [Route("sales/index/all")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Top20NewAndUsedForSales()
        {
            List<Vehicle> vehicles = DealershipRepositoryFactory.Create().GetNewAndUsedVehiclesForSales();

            if (vehicles == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(vehicles);
            }
        }

        [Route("sales/{input}/{minPrice}/{maxPrice}/{minYear}/{maxYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult FilteredNewAndUsedForSales(string input, int minPrice, int maxPrice, int minYear, int maxYear)
        {
            List<Vehicle> vehicles = DealershipRepositoryFactory.Create().GetFilteredNewAndUsedVehiclesForSales(input, minPrice, maxPrice, minYear, maxYear);

            if (vehicles == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(vehicles);
            }
        }

        [Route("sales/purchase/{vehicleId}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult PurchaseByVehicleId(int vehicleId)
        {
            Vehicle vehicle = DealershipRepositoryFactory.Create().GetVehicleDetailsByVehicleId(vehicleId);

            if (vehicle == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(vehicle);
            }
        }

    }
}

