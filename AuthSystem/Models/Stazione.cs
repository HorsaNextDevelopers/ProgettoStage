using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSystem.Models
{
    public class Stazione
    {
        [Key]

        public int IdNomeStazione { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Immettere il nome della stazione")]
        [DisplayName("Nome della stazione di lavoro")]

        public string NomeStazione { get; set; }

        [DisplayName("Nome linea")]
        public int IdLinea { get; set; }

        [ForeignKey("IdLinea")]
        [DisplayName("Nome linea")]
        public Linea Linee { get; set; }

        public ComponenteArticolo ComponentiArticolo { get; set; }
    }
}
