using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoneymoonShop.Models.Bruid
{
    public class Categorie 
    {
        public int Id { get; set; }

        [Required]
        public string Naam { get; set; }

        [NotMapped]
        public bool Selected { get; set; }

        public List<Product> Producten { get; set; }
    }
}
