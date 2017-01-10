using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HoneymoonShop.Models
{
    public class Trouwjurk
    {
        public int Id { get; set; }

        [Required]
        public string ArtikelNummer { get; set; }

        public string beschrijving { get; set; }

        public double Prijs { get; set; }
        
        [Required]
        public Merk Merk { get; set; }

        public List<Stijl> Stijlen { get; set; }

        public List<Neklijn> Neklijnen { get; set; }

        public List<Silhouette> Silhouetten { get; set; }
        
        public List<Kleur> Kleuren { get; set; }
        
        public Categorie Categorie { get; set; }
    }
}
