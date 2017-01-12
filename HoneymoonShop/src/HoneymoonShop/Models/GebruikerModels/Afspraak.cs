using System;
using System.ComponentModel.DataAnnotations;

namespace HoneymoonShop.Models.GebruikerModels
{
    public class Afspraak
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd - MM - yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Datum { get; set; }

        [DisplayFormat(DataFormatString = "{0: hh : mm}", ApplyFormatInEditMode = true)]
        public string Tijd { get; set; }

        public SoortAfspraak AfspraakSoort { get; set; }

        public virtual Gebruiker Gebruiker { get; set; }
    }

    public enum SoortAfspraak {
        Trouwjurken,
        Trouwpakken,
        Afspeldafspraak }
}
