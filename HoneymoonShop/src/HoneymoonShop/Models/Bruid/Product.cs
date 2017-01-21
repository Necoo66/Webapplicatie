using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HoneymoonShop.Models.Bruid;

namespace HoneymoonShop.Models.Bruid
{
    public class Product
    {
        public Product()
        {
            Product_X_Kenmerk = new HashSet<Product_X_Kenmerk>();
        }
        public int Id { get; set; }

        [Required]
        public string ArtikelNummer { get; set; }

        public string Beschrijving { get; set; }

        public double Prijs { get; set; }

        /*categorie kan null zijn*/
        
        public virtual Categorie Categorie { get; set; }

        public virtual Merk Merk { get; set; }

        public virtual HashSet<Product_X_Kenmerk> Product_X_Kenmerk { get; set; }
    }
}
