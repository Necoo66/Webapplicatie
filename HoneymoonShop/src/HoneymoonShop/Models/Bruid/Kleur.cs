using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoneymoonShop.Models.Bruid
{
    [Table("Kleur")]
    public class Kleur : Kenmerk
    {
        [MaxLength(6)]
        //hex value
        public string Kleurcode { get; set; }
    }
}
