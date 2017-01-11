using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HoneymoonShop.Models.Bruid
{
    public class Kleur
    {
        public int Id { get; set; }
        [Required]
        public string naam { get; set; }

        [MaxLength(6)]
        //hex value
        public string Kleurcode { get; set; }

        public List<Afbeelding> Afbeeldingen { get; set; }
    }
}
