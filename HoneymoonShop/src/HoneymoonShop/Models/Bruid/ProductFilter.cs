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

        public ProductFilter(Filter filter, IIncludableQueryable<Product, Kenmerk> trouwjurk)
        {
            Filter = filter;
        }
    }
}
