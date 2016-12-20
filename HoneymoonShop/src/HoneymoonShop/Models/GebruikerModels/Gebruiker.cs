using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoneymoonShop.Models.GebruikerModels
{
    public class Gebruiker
    {
        public Gebruiker()
        {
            Afspraken = new List<Afspraak>();
        }

        public int Id { get; set; }


        [Required]
        [MaxLength(100)]
        public String Naam { get; set; }


        [Required, Column(TypeName = "Date"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Trouwdatum { get; set; }


        [DataType(DataType.PhoneNumber)]
        public int Telefoonnummer { get; set; }


        [Required]
        [DataType(DataType.EmailAddress)]
        public string Emailadres { get; set; }

        public virtual List<Afspraak> Afspraken { get; set; }

    }
}
