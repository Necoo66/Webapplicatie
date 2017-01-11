using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HoneymoonShop.Models.Bruid
{
    public class Merk
    {
        public Merk()
        {
            Producten = new HashSet<Product>();
        }
        public int Id { get; set; }
        [Required]
        public string Naam { get; set; }

        public virtual ICollection<Product> Producten { get; set; }
    }
}
