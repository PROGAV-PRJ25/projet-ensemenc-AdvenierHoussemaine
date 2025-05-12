public class Saison {
    public string NomSaison {get; set;}
    public List<Mois> MoisDeLaSaison {get; set;}

    public Saison(string nomSaison)
    {
        NomSaison=nomSaison;
        if (nomSaison=="Été")
        {
            MoisDeLaSaison = new List<Mois> {"Juin", "Juillet","Août"};
        }
        if (nomSaison=="Automne")
        {
            MoisDeLaSaison = new List<Mois> {"Septembre", "Octobre","Novembre"};
        }
        if (nomSaison=="Hiver")
        {
            MoisDeLaSaison = new List<Mois> {"Décembre", "Janvier","Février"};
        }
        else
        {
            MoisDeLaSaison = new List<Mois> {"Mars", "Avril","Mai"};
        }
    }
}