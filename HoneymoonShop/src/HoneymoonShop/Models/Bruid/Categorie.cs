using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HoneymoonShop.Models.Bruid
{
    public class Categorie
    {
        public int Id { get; set; }
        [Required]
        public string Naam { get; set; }
    }
}
