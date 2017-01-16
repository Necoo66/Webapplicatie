using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoneymoonShop.Models.Bruid
{
    public class FilterOpties
    {
        public FilterOpties()
        {
            Paginanummer = 1;
            AantalTonen = 10;
            SortingOptie = "PrijsHL";
            MinPrijs = 0;
            MaxPrijs = 10000;
        }

        public List<Kenmerk> Kenmerken { get; set; }
        public List<Merk> Merk { get; set; }
        public double MinPrijs { get; set; }
        public double MaxPrijs { get; set; }
        public Categorie Categorie { get; set; }

        public int Paginanummer { get; set; }
        public int AantalTonen { get; set; }
        public string SortingOptie { get; set; }

    }
}
