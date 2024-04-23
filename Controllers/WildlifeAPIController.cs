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
        [Route("api/WildlifeSightings/{speciesId}")]
        public Sighting Get(string speciesId)
        {
            //ensures that the instance of this db connection is disposed of in memory...
            //immediately rather than waiting for GC.
            using (wildlife_sightings_DBEntities db = new wildlife_sightings_DBEntities())
            {
                return db.Sightings.Find(speciesId);
            }
        }
    }
}
