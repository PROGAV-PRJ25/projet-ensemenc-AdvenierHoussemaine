public class Saison {
    public string NomSaison {get; set;}
    public List<Mois> MoisDeLaSaison {get; set;}

    public Saison(string nomSaison)
    {
        NomSaison=nomSaison;
        if (nomSaison=="Été")
        {
            MoisDeLaSaison = new List<Mois>
            {
                new ("Juin"),
                new ("Juillet"),
                new ("Août")
            };

        }
        if (nomSaison=="Automne")
        {
            MoisDeLaSaison = new List<Mois>
            {
                new("Septembre"),
                new("Octobre"),
                new("Novembre")
            };

        }
        if (nomSaison=="Hiver")
        {
            MoisDeLaSaison = new List<Mois>
            {
                new("Décembre"),
                new("Janvier"),
                new("Février")
            };
        }
        else
        {
            MoisDeLaSaison = new List<Mois>
            {
                new("Mars"),
                new("Avril"),
                new("Mai")
            };
        }
    }
}