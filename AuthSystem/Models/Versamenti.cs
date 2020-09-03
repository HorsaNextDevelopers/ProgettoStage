using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;



namespace AuthSystem.Models
{
    public class Versamenti
    {
        [Key]
        public int Id_versamento { get; set; }
        [Column(TypeName = "nchar(250)")]
        [Required(ErrorMessage = "L'identificazione è obbligatoria")]
        [DisplayName("Numero pezzi fabbricati")]
        public float Numero_pezzi { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd\\-mm\\-yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Data versamento")]
        public DateTime Data { get; set; }

        [Column(TypeName = "numeric")]
        [DisplayName("Tempo di produzione (Minuti)")]
        public float Tempo_prod { get; set; }

        [DisplayName("Nome articolo")]
        public int Id_articolo { get; set; }
        [ForeignKey("Id_articolo")]
        [DisplayName("Nome articolo")]
        public Articoli Articoli { get; set; }

    }
}
