using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSystem.Models
{
    public class Linea
    {
        [Key]
        public int IdLinea{ get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Immettere il nome della linea")]
        [DisplayName("Nome della linea")]
        public string NomeLinea { get; set; }

        /*[DisplayName("Nome articolo")]
        public int IdArticolo { get; set; }
        [ForeignKey("IdArticolo")]
        [DisplayName("Nome articolo")]
        public Articolo Articoli { get; set; }*/
        public ICollection<Stazione> Stazioni { get; set; }
    }
}
