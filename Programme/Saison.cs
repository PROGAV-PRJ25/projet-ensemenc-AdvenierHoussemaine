public class Saison
{
    public string nomSaison;
    public List<Mois> MoisDeLaSaison { get; set; } //nous l'instanceron seulement avec des noms de saison valide

    public Saison(string saisonNom)
    {
        nomSaison = saisonNom;
        if (saisonNom == "Été")
        {
            MoisDeLaSaison = new List<Mois>
            {
                new ("Juin"),
                new ("Juillet"),
                new ("Août")
            };

        }
        if (saisonNom == "Automne")
        {
            MoisDeLaSaison = new List<Mois>
            {
                new("Septembre"),
                new("Octobre"),
                new("Novembre")
            };

        }
        if (saisonNom == "Hiver")
        {
            MoisDeLaSaison = new List<Mois>
            {
                new("Décembre"),
                new("Janvier"),
                new("Février")
            };
        }
        else if (saisonNom == "Printemps")
        {
            MoisDeLaSaison = new List<Mois>
            {
                new("Mars"),
                new("Avril"),
                new("Mai")
            };
        }
        else
        {
            //cas théorique mais n'est jamais realise
            MoisDeLaSaison = new List<Mois> { };
        }
    }
}