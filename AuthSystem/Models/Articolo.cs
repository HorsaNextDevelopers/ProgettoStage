using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSystem.Models
{
    public class Articolo
    {
        [Key]
        public int IdArticolo { get; set; }
        
        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Immettere il nome dell'articolo")]
        [DisplayName("Nome articolo")]
        public string NomeArticolo { get; set; }
        
        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Immettere la descrizione dell'articolo")]
        [DisplayName("Descrizione articolo")]
        public string Descrizione { get; set; }
        
        [Column(TypeName = "numeric")]
        [DisplayName("Tempo produzione (Singolo articolo)")]
        [Required(ErrorMessage = "Immettere il tempo di produzione del singolo articolo")]
        public float TempoProduzione { get; set; }

        public ICollection<Versamento> Versamenti { get; set; }
        
    }
}
