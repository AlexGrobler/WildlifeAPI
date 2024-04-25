using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WildlifeAPI.Models;
using static System.Net.WebRequestMethods;

namespace WildlifeAPI.Controllers
{
    public class WildlifeAPIController : ApiController
    {
        private wildlife_sightings_DBEntities db = new wildlife_sightings_DBEntities(); 

        [HttpGet]
        [Route("api/WildlifeSightings/BySpecies/{speciesId}")]
        public IHttpActionResult GetSightingsBySpecies(int speciesId)
        {
            using (wildlife_sightings_DBEntities db = new wildlife_sightings_DBEntities())
            {
                var sightings = db.Sightings.Where(s => s.SpeciesID == speciesId).ToList();
                if (sightings != null)
                {
                    return Ok(sightings);  //follows RESTFul API principles to return feedback to the client
                }
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/WildlifeSightings/All")]
        public IHttpActionResult GetAllSightings()
        {
            using (wildlife_sightings_DBEntities db = new wildlife_sightings_DBEntities())
            {
                return Ok(db.Sightings.ToList());  //follows RESTFul API principles to return feedback to the client
            }
        }

        [HttpGet]
        [Route("api/WildlifeSightings/BySighting/{id}")]
        public IHttpActionResult Get(int id)
        {
            using (wildlife_sightings_DBEntities db = new wildlife_sightings_DBEntities())
            {
                var sighting = db.Sightings.Find(id);
                if (sighting != null)
                {
                    return Ok(sighting);  //follows RESTFul API principles to return feedback to the client
                }
                return NotFound();    
            }
        }

        [HttpPost]
        [Route("api/WildlifeSightings/CreateSighting")]
        public IHttpActionResult CreateSighting(Sighting sighting)
        {
            using (var db = new wildlife_sightings_DBEntities())
            {
                if (ModelState.IsValid)
                {
                    db.Sightings.Add(sighting);
                    db.SaveChanges();
                    return CreatedAtRoute("Default", new { id = sighting.ID }, sighting); //follows RESTFul API principles to return feedback to the client
                }
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [Route("api/WildlifeSightings/UpdateSighting")]
        public IHttpActionResult UpdateSighting(Sighting sighting)
        {
            using (var db = new wildlife_sightings_DBEntities()) 
            {
                if (ModelState.IsValid)
                {
                    var dbSighting = db.Sightings.FirstOrDefault(s => s.ID == sighting.ID);
                    if (dbSighting == null)
                    {
                        return NotFound();
                    }

                    db.Entry(dbSighting).CurrentValues.SetValues(sighting);
                    db.SaveChanges();
                    return Ok(dbSighting); //follows RESTFul API principles to return feedback to the client
                }
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("api/WildlifeSightings/DeleteSighting/{id}")]
        public IHttpActionResult DeleteSighting(int id)
        {
            using (var db = new wildlife_sightings_DBEntities())
            {
                try
                {
                    var dbSighting = db.Sightings.Find(id);
                    if (dbSighting == null)
                    {
                        return NotFound();
                    }

                    db.Sightings.Remove(dbSighting);
                    db.SaveChanges();
                    return Ok(dbSighting);
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }
        }
    }
}
