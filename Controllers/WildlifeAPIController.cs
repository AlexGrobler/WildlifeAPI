using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WildlifeAPI.Models;
using static System.Net.WebRequestMethods;

namespace WildlifeAPI.Controllers
{
    public class WildlifeAPIController : ApiController
    {
        [HttpGet]
        [Route("api/WildlifeSightings/BySpecies/{speciesId}")]
        public async Task<IHttpActionResult> GetSightingsBySpecies(int speciesId)
        {
            using (wildlife_sightings_DBEntities db = new wildlife_sightings_DBEntities())
            {
                var sightings = await db.Sightings.Where(s => s.SpeciesID == speciesId).ToListAsync();
                if (sightings != null)
                {
                    return Ok(sightings);  //follows RESTFul API principles to return feedback to the client
                }
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/WildlifeSightings/All")]
        public async Task<IHttpActionResult> GetAllSightings()
        {
            using (wildlife_sightings_DBEntities db = new wildlife_sightings_DBEntities())
            {
                return Ok(await db.Sightings.ToListAsync());  //follows RESTFul API principles to return feedback to the client
            }
        }

        [HttpGet]
        [Route("api/WildlifeSightings/BySighting/{id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            using (wildlife_sightings_DBEntities db = new wildlife_sightings_DBEntities())
            {
                var sighting = await db.Sightings.FindAsync(id);
                if (sighting != null)
                {
                    return Ok(sighting);  //follows RESTFul API principles to return feedback to the client
                }
                return NotFound();    
            }
        }

        [HttpPost]
        [Route("api/WildlifeSightings/CreateSighting")]
        public async Task<IHttpActionResult> CreateSighting(Sighting sighting)
        {
            using (var db = new wildlife_sightings_DBEntities())
            {
                if (ModelState.IsValid)
                {
                    db.Sightings.Add(sighting);
                    await db.SaveChangesAsync();
                    return CreatedAtRoute("Default", new { id = sighting.ID }, sighting); //follows RESTFul API principles to return feedback to the client
                }
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [Route("api/WildlifeSightings/UpdateSighting")]
        public async Task<IHttpActionResult> UpdateSighting(Sighting sighting)
        {
            using (var db = new wildlife_sightings_DBEntities()) 
            {
                if (ModelState.IsValid)
                {
                    var dbSighting = await db.Sightings.FirstOrDefaultAsync(s => s.ID == sighting.ID);
                    if (dbSighting == null)
                    {
                        return NotFound();
                    }

                    db.Entry(dbSighting).CurrentValues.SetValues(sighting);
                    await db.SaveChangesAsync();
                    return Ok(dbSighting); //follows RESTFul API principles to return feedback to the client
                }
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("api/WildlifeSightings/DeleteSighting/{id}")]
        public async Task<IHttpActionResult> DeleteSighting(int id)
        {
            using (var db = new wildlife_sightings_DBEntities())
            {
                try
                {
                    var dbSighting = await db.Sightings.FindAsync(id);
                    if (dbSighting == null)
                    {
                        return NotFound();
                    }

                    db.Sightings.Remove(dbSighting);
                    await db.SaveChangesAsync();
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
