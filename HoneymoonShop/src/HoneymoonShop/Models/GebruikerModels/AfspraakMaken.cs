namespace HoneymoonShop.Models.GebruikerModels
{
    public class AfspraakMaken
    {
        public Afspraak Afspraak { get; set; }
        public Gebruiker Gebruiker { get; set; }

        public AfspraakMaken()
        {
            Afspraak = new Afspraak();
            Gebruiker = new Gebruiker();
        }
    }
}
