using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSystem.Models
{
    public class Articoli
    {
        [Key]
        public int Id_articolo { get; set; }
        
        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "L'identificazione è obbligatoria")]
        [DisplayName("Nome articolo")]
        public string Nome_Articolo { get; set; }
        
        [Column(TypeName = "nvarchar(250)")]
        [DisplayName("Descrizione articolo")]
        public string Descrizione { get; set; }
        
        [Column(TypeName = "numeric")]
        [DisplayName("Tempo produzione (Singolo articolo)")]
        public float Tempo_produzione { get; set; }

        public ICollection<Versamenti> Versamentis { get; set; }
        
    }
}
