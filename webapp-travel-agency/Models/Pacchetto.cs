using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapp_travel_agency.Models
{
    public class Pacchetto
    {
        [Key]
        public int Id { get; set; }

        [Range(0, int.MaxValue)]
        public int Prezzo { get; set; }

        [Required(ErrorMessage = "il campo nome è obbligatorio")]
        [StringLength(50)]
        public string Title { get; set; }

        [Required(ErrorMessage = "il campo descrizione è obbligatorio")]
        [Column(TypeName = "text")]
        public string Description { get; set; }

        [Required(ErrorMessage = "il campo immagine è obbligatorio")]
        public string Image { get; set; }


        public Pacchetto()
        {

        }

        public Pacchetto(int Prezzo, string Title, string Description, string Image)
        {
            this.Prezzo = Prezzo;
            this.Title = Title; 
            this.Description = Description;
            this.Image = Image;

        }
    }
}
