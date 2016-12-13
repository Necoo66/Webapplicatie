using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webapplicatie.Models
{
    public class Gebruiker
    {
        [Key]
        [Required]
        public int id { get; set; }

        [Required]
        [MaxLength(100)]
        public String naam { get; set; }

        [DataType(DataType.Date)]
        public DateTime Trouwdatum { get; set; }

    }
}
