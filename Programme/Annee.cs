public class Annee {
    public List<Saison> AnneeActuel {get; set;}
    //On commence en mars 2025
    public static int NomDeLannee = 2025;
    public static int SaisonActuel = 0;
    public static int MoisActuel = 0;

    public Annee ()
    {
            AnneeActuel = new List<Saison>
        {
            new ("Printemps"),
            new ("Été"),
            new ("Automne"),
            new ("Hiver")
        };
    }

    public void ChangerDeMois()
    {
        if(MoisActuel==2)
        {
            MoisActuel=0;
            if(SaisonActuel==11)
        }
        else
        {
            MoisActuel++;
        }
    }


    //methode changer de mois 
    //eventuelement un to string permettant de faire un résumé de l'année
}