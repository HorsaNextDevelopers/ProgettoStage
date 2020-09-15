using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSystem.Models
{
    public class ComponenteArticolo
    {
        [Key]
        public int IdComponente { get; set; }

        [Column(TypeName = "nchar(250)")]
        [Required(ErrorMessage = "Immettere il nome del componente")]
        [DisplayName("Nome del componente")]
        public string NomeComponente { get; set; }

        [DisplayName("Nome articolo")]
        public int IdArticolo { get; set; }
        [ForeignKey("IdArticolo")]
        [DisplayName("Nome articolo")]
        public Articolo Articoli { get; set; }
    }
}
