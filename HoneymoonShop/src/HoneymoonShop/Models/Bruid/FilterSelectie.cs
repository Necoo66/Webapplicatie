using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoneymoonShop.Models.Bruid
{
    /*
    Classe met geselecteerde filters
    variable zijn lijsten met ID's 
    */
    public class FilterSelectie
    {
        public FilterSelectie()
        {
            Paginanummer = 1;
            AantalTonen = 10;
            SortingOptie = "PrijsHL";
            MinPrijs = 0;
            MaxPrijs = 10000;
            Kenmerken = new List<int>();
            Merken = new List<int>();
        }

        public List<int> Kenmerken { get; set; }
        public List<int> Merken { get; set; }
        public double MinPrijs { get; set; }
        public double MaxPrijs { get; set; }
        public int Categorie { get; set; }

        public int Paginanummer { get; set; }
        public int AantalTonen { get; set; }
        public string SortingOptie { get; set; }

    }
}
