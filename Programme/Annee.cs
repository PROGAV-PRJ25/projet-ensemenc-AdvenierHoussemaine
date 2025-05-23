using System.Xml.Serialization;

public class Annee {
    public List<Saison> AnneeActuel {get; private set;}
    //On commence en mars 2025
    public int NomDeLannee = 2025;
    private int SaisonActuel = 1;//On commence en Mars
    private int MoisActuel = 0;

    public Annee ()
    {
            AnneeActuel = new List<Saison>
        {
            new ("Hiver"),
            new ("Printemps"),
            new ("Été"),
            new ("Automne")
            
        };
    }

    public void ChangerDeMois()
    {
        if (MoisActuel == 0 && SaisonActuel == 0) //on a besoin de changer d'annee
        {
            NomDeLannee++;
        }
        if (MoisActuel == 2) // on a fini une saison
        {
            MoisActuel = -1; //pour revenir sur 0 plus tard
            if (SaisonActuel == 3) // on a fini l'annee
            {
                SaisonActuel = -1;
            }
            SaisonActuel++;
        }
        MoisActuel++;
    }


    public Mois DonnerLeMois()
    {
        return AnneeActuel[SaisonActuel].MoisDeLaSaison[MoisActuel];
    }

    public override string ToString()
    {
        
        Mois mois = AnneeActuel[SaisonActuel].MoisDeLaSaison[MoisActuel];  
        return $"{mois.NomDuMois} {NomDeLannee} \n  --> La météo est la suivante :\n        - Température moyenne : {mois.Temperature} °C\n        - Cm de pluie dans le mois : {mois.Pluviometrie} cm\n        - Taux de lumiére moyenne pendant une journée : {mois.Ensoleillement}";
    }
    //methode changer de mois 
    //eventuelement un to string permettant de faire un résumé de l'année
}