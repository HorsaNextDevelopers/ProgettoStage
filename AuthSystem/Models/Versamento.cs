using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AuthSystem.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Identity;

namespace AuthSystem.Models
{
 
    public class Versamento
    {
        [Key]
        public int IdVersamento { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Immettere il numero dei pezzi fabbricati")]
        [DisplayName("Numero pezzi buoni")]
        public float PezziBuoni { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Immettere il numero dei pezzi fabbricati")]
        [DisplayName("Numero pezzi difettosi")]
        public float PezziDifettosi { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd\\-MM\\-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Immettere la data aggiornata")]
        [DisplayName("Data versamento")]
        public DateTime Data { get; set; }

        [Column(TypeName = "numeric")]
        [DisplayName("Tempo produzione (Minuti)")]
        [Required(ErrorMessage = "Immettere il tempo di produzione di tutti gli articoli")]
        public float TempoProd { get; set; }

        [DisplayName("Nome componente")]
        public int IdComponente { get; set; }
        [ForeignKey("IdComponente")]
        [DisplayName("Nome componente")]
        public ComponenteArticolo ComponentiArticolo { get; set; }

        [DisplayName("Nome stazione")]
        public int IdNomeStazione { get; set; }
        [ForeignKey("IdNomeStazione ")]
        [DisplayName("Nome stazione")]
        public Stazione Stazioni { get; set; }

        [MaxLength(450), ForeignKey("AspNetUsers"),DisplayName("Email") ]
        public string IdAspNetUsers { get; set; }
       
        [DisplayName("Email")]
        public ApplicationUser AspNetUsers { get; set; }


    }
}
