using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HoneymoonShop.Models.Bruid
{
    public class Kenmerk
    {
        public int Id { get; set; }
        [Required]
        public string Naam { get; set; }
        public string KenmerkType { get; set; }
    }
}
