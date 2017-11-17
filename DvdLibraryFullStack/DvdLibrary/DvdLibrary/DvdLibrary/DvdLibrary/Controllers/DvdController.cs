using DvdLibrary.Data;
using DvdLibrary.Data.Repositories;
using DvdLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DvdLibrary.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DvdController : ApiController
    {
        [Route("dvd/{dvdId}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdById(int dvdId)
        {
            Dvd dvd = DvdRepositoryFactory.Create().GetDvdById(dvdId);

            if (dvd == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvd);
            }
        }

        [Route("dvds")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllDvds()
        {
            List<Dvd> dvds = DvdRepositoryFactory.Create().GetAllDvds();

            if (dvds == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvds);
            }
        }

        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdByTitle(string title)
        {
            List<Dvd> dvds = DvdRepositoryFactory.Create().GetDvdByTitle(title);

            if (dvds == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvds);
            }
        }

        [Route("dvds/year/{releaseYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdByYear(int releaseYear)
        {
            List<Dvd> dvds = DvdRepositoryFactory.Create().GetDvdByYear(releaseYear);

            if (dvds == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvds);
            }
        }

        [Route("dvds/director/{directorName}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdByDirector(string directorName)
        {
            List<Dvd> dvds = DvdRepositoryFactory.Create().GetDvdByDirector(directorName);

            if (dvds == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvds);
            }
        }

        [Route("dvds/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdByRating(string rating)
        {
            List<Dvd> dvds = DvdRepositoryFactory.Create().GetDvdByRating(rating);

            if (dvds == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvds);
            }
        }

        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult CreateNewDvd(Dvd newDvd)
        {
           if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Dvd dvd = new Dvd()
            {
                Title = newDvd.Title,
                Director = newDvd.Director,
                Rating = newDvd.Rating,
                ReleaseDate = newDvd.ReleaseDate,
                Notes = newDvd.Notes
            };

            DvdRepositoryFactory.Create().CreateDvd(newDvd);
            return Created($"dvd/{newDvd.DvdId}", newDvd);
        }

        [Route("dvd/{dvdId}")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult UpdateDvd(Dvd newDvd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Dvd dvd = DvdRepositoryFactory.Create().GetDvdById(newDvd.DvdId);

            if(dvd == null)
            {
                return NotFound();
            }

            dvd.Title = newDvd.Title;
            dvd.Director = newDvd.Director;
            dvd.Rating = newDvd.Director;
            dvd.ReleaseDate = newDvd.ReleaseDate;
            dvd.Notes = newDvd.Notes;

            DvdRepositoryFactory.Create().UpdateDvd(newDvd);
            return Ok(dvd);
        }

        [Route("dvd/{dvdId}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult DeleteDvd(int dvdId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Dvd dvd = DvdRepositoryFactory.Create().GetDvdById(dvdId);

            if (dvd == null)
            {
                return NotFound();
            };

            DvdRepositoryFactory.Create().DeleleteDvd(dvdId);
            return Ok();
        }
    }
}
