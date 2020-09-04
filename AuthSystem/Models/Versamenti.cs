using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AuthSystem.Areas.Identity.Data;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Identity;

namespace AuthSystem.Models
{
    public class Versamenti
    {
        [Key]
        public int Id_versamento { get; set; }
        [Column(TypeName = "nchar(250)")]
        [Required(ErrorMessage = "Immettere il numero dei pezzi fabbricati")]
        [DisplayName("Numero pezzi fabbricati")]
        public float Numero_pezzi { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd\\-mm\\-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Immettere la data aggiornata")]
        [DisplayName("Data versamento")]
        public DateTime Data { get; set; }

        [Column(TypeName = "numeric")]
        [DisplayName("Tempo di produzione (Minuti)")]
        [Required(ErrorMessage = "Immettere il tempo di produzione di tutti gli articoli")]
        public float Tempo_prod { get; set; }

        [DisplayName("Nome articolo")]
        public int Id_articolo { get; set; }
        [ForeignKey("Id_articolo")]
        [DisplayName("Nome articolo")]
        public Articoli Articoli { get; set; }

        public string Email { get; set; }
        [ForeignKey("Email")]
        [DisplayName("Email")]
        public Utenti AspNetUsers { get; set; }


    }
}
