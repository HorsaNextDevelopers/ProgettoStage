using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSystem.Models
{
    [Table("AspNetUsers")]
    public class Utenti
    {
        [Key]
        public string Id { get; set; }
        public string Email { get; set; }
    }
}
