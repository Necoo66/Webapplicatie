using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using HoneymoonShop.Models.GebruikerModels;

namespace HoneymoonShop.Models.Bruid
{
    /*Alle filter opties vanuit de database*/
    public class Filter
    {
        public double MinPrijs { get; set; }
        public double MaxPrijs { get; set; }
        public List<Categorie> Categorieën { get; set; }
        public List<Merk> Merken { get; set; }
        public List<Kenmerk> Stijlen { get; set; }
        public List<string> KenmerkNamen { get; set; }
        public List<Kenmerk> Kenmerken { get; set; }

        public Filter()
        {
            MinPrijs = 0;
            MaxPrijs = 10000;
            Categorieën = new List<Categorie>();
            Merken = new List<Merk>();
            Kenmerken = new List<Kenmerk>();
            Stijlen = new List<Kenmerk>();
            KenmerkNamen = new List<string>();
        }

        public Filter(double minPrijs, double maxPrijs, List<Categorie> categorieën, List<Merk> merken, List<Kenmerk> stijlen, List<string> kenmerkNamen, List<Kenmerk> kenmerken)
        {
            MinPrijs = minPrijs;
            MaxPrijs = maxPrijs;
            Categorieën = categorieën;
            Merken = merken;
            Stijlen = stijlen;
            KenmerkNamen = kenmerkNamen;
            Kenmerken = kenmerken;
        }
    }
}
