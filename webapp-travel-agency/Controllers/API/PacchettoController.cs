using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapp_travel_agency.Data;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacchettoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<Pacchetto> pacchetti = new List<Pacchetto>();

            using (PacchettoContext db = new PacchettoContext())
            {
                pacchetti = db.pacchetti.ToList<Pacchetto>();
            }
            return Ok(pacchetti);
        }

    }
}
