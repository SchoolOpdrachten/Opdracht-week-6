using Models;

namespace Services
{
    public class MedewerkerService
    {
        public PretparkContext Context { get; set; }
        public Attractie MaakAttractie(string naam, int engheid, DateTime bouwjaar)
        {
            Attractie attractie = new Attractie
            {
                Naam = naam,
                Engheid = engheid,
                Bouwjaar = bouwjaar
            };
            Context.Add(attractie);
            Context.SaveChanges();
            return attractie;
        }

        public void VerwijkerAttractie(Attractie attractie)
        {
            Context.Remove(attractie);
            Context.SaveChanges();
        }
    }
}