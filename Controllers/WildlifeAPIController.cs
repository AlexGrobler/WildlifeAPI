using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WildlifeAPI.Models;

namespace WildlifeAPI.Controllers
{
    public class WildlifeAPIController : ApiController
    {
        [Route("api/WildlifeSightings/BySpecies/{speciesId}")]
        public IEnumerable<Sighting> GetSightingsBySpecies(int speciesId)
        {
            using (wildlife_sightings_DBEntities db = new wildlife_sightings_DBEntities())
            {
                return db.Sightings.Where(s => s.SpeciesID == speciesId).ToList();
            }
        }

        [Route("api/WildlifeSightings/All")]
        public IEnumerable<Sighting> GetAllSightings()
        {
            using (wildlife_sightings_DBEntities db = new wildlife_sightings_DBEntities())
            {
                return db.Sightings.ToList();
            }
        }

        [Route("api/WildlifeSightings/BySighting/{id}")]
        public Sighting Get(int id)
        {
            using (wildlife_sightings_DBEntities db = new wildlife_sightings_DBEntities())
            {
                return db.Sightings.Find(id);
            }
        }


    }
}
