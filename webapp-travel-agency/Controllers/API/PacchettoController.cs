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
        public IActionResult Get(string? search)
        {
            List<Pacchetto> pacchetti = new List<Pacchetto>();


            using (PacchettoContext db = new PacchettoContext())
            {
                if (search != null && search != "")
                {
                    pacchetti = db.pacchetti.Where(pacchetti => pacchetti.Title.Contains(search) || pacchetti.Description.Contains(search)).ToList<Pacchetto>();
                }
                else
                {
                    pacchetti = db.pacchetti.ToList<Pacchetto>();
                }
            }
            return Ok(pacchetti);
        }

    }
}
