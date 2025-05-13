using System.Xml.Serialization;

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
        if(MoisActuel==0 || SaisonActuel==3) //on etais en decembre
        {
            NomDeLannee++;
            MoisActuel++;
        }
        else if (MoisActuel==2) // il y a changement de saison
        {
            MoisActuel=0;
            if(SaisonActuel==3) //on etais en fevrier
            {
                SaisonActuel=0; //on arrive au printemps

            }
            else
            {
                SaisonActuel++;
            }
        }
        else //il n'y a pas de changement d'année ou de saison
        {
            MoisActuel++;
        }
    }

    //eventuelement un to string permettant de faire un résumé de l'année
}