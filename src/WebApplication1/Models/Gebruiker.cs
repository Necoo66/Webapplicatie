using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Webapplicatie.Models
{
    public class Gebruiker
    {
        public int id { get; set; }

        [Required]
        [MaxLength(100)]
        public String naam { get; set; }

        [Required, Column(TypeName = "Date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Trouwdatum { get; set; }

        [DataType(DataType.PhoneNumber)]
        public int Telefoonnummer { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Emailadres { get; set; }

    }
}
