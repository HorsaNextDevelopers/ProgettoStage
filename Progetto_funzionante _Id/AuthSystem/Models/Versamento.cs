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
    public class Versamento
    {
        [Key]
        public int IdVersamento { get; set; }
        [Column(TypeName = "nchar(250)")]
        [Required(ErrorMessage = "Immettere il numero dei pezzi fabbricati")]
        [DisplayName("Numero pezzi fabbricati")]
        public float NumeroPezzi { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd\\-MM\\-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Immettere la data aggiornata")]
        [DisplayName("Data versamento")]
        public DateTime Data { get; set; }

        [Column(TypeName = "numeric")]
        [DisplayName("Tempo di produzione (Minuti)")]
        [Required(ErrorMessage = "Immettere il tempo di produzione di tutti gli articoli")]
        public float TempoProd { get; set; }

        [DisplayName("Nome articolo")]
        public int IdArticolo { get; set; }
        [ForeignKey("IdArticolo")]
        [DisplayName("Nome articolo")]
        public Articolo Articoli { get; set; }

        [MaxLength(450), ForeignKey("AspNetUsers"),DisplayName("Email") ]
        public string IdAspNetUsers { get; set; }
       
        [DisplayName("Email")]
        public ApplicationUser AspNetUsers { get; set; }


    }
}
