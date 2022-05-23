using Microsoft.AspNetCore.Mvc;
using webapp_travel_agency.Data;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers
{
    public class PacchettoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<Pacchetto> pacchetti = new List<Pacchetto>();

            using (PacchettoContext db = new PacchettoContext())
            {
                pacchetti = db.pacchetti.ToList<Pacchetto>();
            }
            return View("HomePage", pacchetti);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Pacchetto pacchettoTrovato = null;

            using (PacchettoContext db = new PacchettoContext())
            {
               
                 pacchettoTrovato = db.pacchetti
                    .Where(pacchetto => pacchetto.Id == id)
                    .First(); //restituisce il primo elemento che avrà l id associato
            }
                if (pacchettoTrovato != null)
                {
                    return View("Details", pacchettoTrovato);
                }
                else
                {
                    return NotFound("il pacchetto con id" + id + " non è stato trovato");
                }
           
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("Form");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pacchetto Nuovopacchetto)
        {
            if (!ModelState.IsValid)
            {
                return View("Form", Nuovopacchetto);
            }
            using (PacchettoContext db = new PacchettoContext()) 
            {
                Pacchetto PacchettoDaCreare = new Pacchetto(Nuovopacchetto.Prezzo, Nuovopacchetto.Title, Nuovopacchetto.Description, Nuovopacchetto.Image);
                db.Add(PacchettoDaCreare);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Pacchetto PacchettoDaModificare = null;

            using (PacchettoContext db = new PacchettoContext())
            {

                PacchettoDaModificare = db.pacchetti
                   .Where(pacchetto => pacchetto.Id == id)
                   .First();
            }
            if (PacchettoDaModificare == null)
            {
                return NotFound();
            }
            else
            {
                return View("Update",PacchettoDaModificare);
            }

        }
        [HttpPost]
        public IActionResult Update(int id, Pacchetto model)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", model);
            }
            else
            {
                Pacchetto PacchettoDaModificare = null;
                using (PacchettoContext db = new PacchettoContext())
                {

                    PacchettoDaModificare = db.pacchetti
                       .Where(pacchetto => pacchetto.Id == id)
                       .First();

                    if (PacchettoDaModificare != null)
                    {
                        PacchettoDaModificare.Title = model.Title;
                        PacchettoDaModificare.Description = model.Description;
                        PacchettoDaModificare.Prezzo = model.Prezzo;
                        PacchettoDaModificare.Image = model.Image;

                        db.SaveChanges();

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            using (PacchettoContext db = new PacchettoContext())
            {
               Pacchetto PacchettoDaEliminare = db.pacchetti
                      .Where(pacchetto => pacchetto.Id == id)
                      .First();

                if(PacchettoDaEliminare != null)
                {
                    db.pacchetti.Remove(PacchettoDaEliminare);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
        }
    }
}
