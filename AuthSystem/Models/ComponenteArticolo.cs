using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthSystem.Models
{
    public class ComponenteArticolo
    {
        [Key]
        public int IdComponente { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Immettere il nome del componente")]
        [DisplayName("Nome del componente")]
        public string NomeComponente { get; set; }

        [Column(TypeName = "numeric")]
        [DisplayName("Tempo produzione (Singolo articolo)")]
        [Required(ErrorMessage = "Immettere il tempo di produzione del singolo articolo")]
        public float TempoProduzione { get; set; }

        [DisplayName("Nome articolo")]
        public int IdArticolo { get; set; }
        [ForeignKey("IdArticolo")]
        [DisplayName("Nome articolo")]
        public Articolo Articoli { get; set; }
    }
}
