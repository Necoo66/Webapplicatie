using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HoneymoonShop.Models.Bruid
{
    public class Kenmerk
    {
        public Kenmerk()
        {
            Product_X_Kenmerk = new HashSet<Product_X_Kenmerk>();
        }
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Naam { get; set; }

        public virtual HashSet<Product_X_Kenmerk> Product_X_Kenmerk { get; set; }


    }
}
