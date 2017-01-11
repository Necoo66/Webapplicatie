using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HoneymoonShop.Models.Bruid
{
    public class Merk
    {
        public int Id { get; set; }
        [Required]
        public string naam { get; set; }
    }
}
