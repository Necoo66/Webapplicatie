using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoneymoonShop.Models.Bruid
{
    public class Product_X_Kenmerk
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int KenmerkId { get; set; }
        public Kenmerk Kenmerk { get; set; }
    }
}
