using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace HoneymoonShop.Models.GebruikerModels
{
    public class Gebruiker
    {
        public Gebruiker()
        {
            Afspraken = new List<Afspraak>();
        }

        public int Id { get; set; }

        [MaxLength(100),
        Required(ErrorMessage = "Voor- en achternaam zijn verijst"),
        VoorEnAchternaam,
        Display(Name = "Voor- en achternaam*")]
        public String VoornaamAchternaam { get; set; }

        [Required(ErrorMessage = "Trouwdatum is vereist"),
        Column(TypeName = "Date"), DataType(DataType.Date),
        DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}"),
        Display(Name = "Trwoudatum*")]
        public DateTime Trouwdatum { get; set; }

        [DataType(DataType.PhoneNumber),
        Display(Name = "Telefoonnummer")]
        public string Telefoonnummer { get; set; }

        [Required(ErrorMessage = "E-mail is vereist"),
        DataType(DataType.EmailAddress),
        Display(Name = "E-mailadres*")]
        public string Email { get; set; }

        [NotMapped,
        DataType(DataType.EmailAddress),
        Compare("Email", ErrorMessage = "De e-mail adressen komen niet overeen"),
        Display(Name = "E-mailadres bevestigen")]
        public string EmailBevestiging { get; set; }

        [Display(Name = "Nieuwsbrief")]
        public bool Nieuwsbrief { get; set; }

        public List<Afspraak> Afspraken { get; set; }

        public class VoorEnAchternaam : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var text = value as string;
                if (value != null)
                {
                    if (2 <= text?.Split().Length)
                    {
                        return ValidationResult.Success;
                    }
                }
                return new ValidationResult("Voor- en achternaam zijn verijst");
            }
        }
    }
}
