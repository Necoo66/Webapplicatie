using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;

namespace HoneymoonShop.Models.Bruid
{
    public class ProductFilter
    {
        public Filter Filter { get; set; }
        public FilterOpties FilterOpties { get; set; }
        public List<Product> Producten { get; set; }

        public ProductFilter(Filter filter, FilterOpties filterOpties, List<Product> producten)
        {
            Filter = filter;
            FilterOpties = filterOpties;
            Producten = producten;
        }

        public ProductFilter()
        {
        }
    }
}
