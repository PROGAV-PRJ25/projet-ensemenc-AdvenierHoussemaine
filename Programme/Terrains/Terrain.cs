using System.Reflection;
using System.Text;

public abstract class Terrain
{
    public bool TerrainProtege {get; set;}
    public double HumiditeTerrain {get; set;} //Allant de 0(très sec) à 1(très humide)
    public double AbsorbtionDeLeau {get; set;} // allant de 0(absorbe rien) à (1 absorbe pleinement)
    public double EnsoleillementTerrain {get; set;} //Allant de 0(ombragé) à 1(plein soleil)
    public List<Parcelle> Parcelles {get; set;} //Dans chaque terrain, il y a 12 emplacements pour planter des plantes. Dans chacune des ces parcelles, il y a 6 "unités d'espace".
    public string TypeTerrain {get; set;} = string.Empty; //Determine si le terrain est argileux, rocheux, tourbière ou sableux.

    public Terrain()
    {
        EnsoleillementTerrain = 0.5; //La valeur par défault au moment de l'initalisation.
        if (TypeTerrain == "Tourbière") {HumiditeTerrain = 1 ; AbsorbtionDeLeau = 0.1;}
        else if (TypeTerrain == "Argileux") {HumiditeTerrain = 0.4; AbsorbtionDeLeau = 0.3;}
        else if (TypeTerrain == "Sableux") {HumiditeTerrain = 0.7; AbsorbtionDeLeau = 0.5;}
        else if (TypeTerrain == "Rocheux") {HumiditeTerrain = 0.2; AbsorbtionDeLeau = 0.7;}
        //Lorsque l'on initalise un terrain, il est fait d'emplacements vides '🟤'.
        Parcelles  = new List<Parcelle> {};
        for (int i=0; i<6; i++)
        {
            //Lorsque l'on initalise un terrain, il est fait d'emplacements vides '🟤'.
            String [] charInitiaux = new string[] {"🟤 ", "🟤 ","🟤 ", "🟤 ", "🟤 ", "🟤 ", "🟤 ", "🟤 ","🟤 ", "🟤 ", "🟤 ", "🟤 "};
            Parcelle parcelle = new Parcelle(i+1, charInitiaux);
            PlanteNull Plantenull = new PlanteNull(parcelle);
            parcelle.Plantes.Add(Plantenull); //AJoute que des plantes nulles à l'initalisation.
            parcelle.HumiditeParcelle = HumiditeTerrain;
            parcelle.EnsoleillementParcelle = EnsoleillementTerrain;
            Parcelles.Add(parcelle);
        }
    }
    
    public void Proteger()
    {
      TerrainProtege = true;
    }

    //AFFICHAGE MODE CLASSIQUE
    public void ToClassiqueString() //Si ca fonctionne pas, faire Console.Writeline(affichage)
    {   
        string affichageSousTerrain = " ";
        if (TerrainProtege == true)
        {
            affichageSousTerrain += "\n                  🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱🧱";
        }
        foreach (var parcelle in Parcelles)
        {
            string elementsListe = " ";
            foreach (var element in parcelle.Emplacements)
            {
                elementsListe += element;
            }
            affichageSousTerrain += $"\n    Parcelle {parcelle.NumParcelle} : {elementsListe}";
        }
        string affichage = $"\n     -> Type : {TypeTerrain}\n     -> Humidité : {HumiditeTerrain} \n Voici le détail des parcelles : {affichageSousTerrain}";
        Console.WriteLine(affichage);
    }

    //AFFICHAGE MODE URGENCE
    public void ToUrgenceString() 
    {   
        //On veut afficher toutes les parcelles de cette facon
        //  [Parcelle 1] [Parcelle 2] [Parcelle 3]
        //  [Parcelle 4] [Parcelle 5] [Parcelle 6]
        //Et chaque parcelle est divisé en deux lignes d'emplacements : 
        //  oooooo
        //  oooooo
        string affichage = "";
        //AFFICHAGE DES 3 PREMIERES PARCELLES
        //Affiche la première ligne 
        for(int i=0; i<3; i++)
        {
            affichage += "  ";
            for(int j=0; j<6; j++)
            {
                affichage += $"{Parcelles[i].Emplacements[j]}";
            }
        }
        //Affiche la deuxième ligne
        affichage += "\n";
        for(int i=0; i<3; i++)
        {
            affichage += "  ";
            for(int j=6; j<12; j++)
            {
                affichage += $"{Parcelles[i].Emplacements[j]}";
            }
        }
        //Affiche le nom des parcelles
        affichage += "\n     Parcelle 1        Parcelle 2        Parcelle 3";
        //AFFICHAGE DES 3 PARCELLES SUIVANTES
        //Affiche la première ligne
        affichage += "\n";
        for(int i=3; i<6; i++)
        {
            affichage += "  ";
            for(int j=0; j<6; j++)
            {
                affichage += $"{Parcelles[i].Emplacements[j]}";
            }
        }
        //Affiche la deuxième ligne
        affichage += "\n";
        for(int i=3; i<6; i++)
        {
            affichage += "  ";
            for(int j=6; j<12; j++)
            {
                affichage += $"{Parcelles[i].Emplacements[j]}";
            }
        }
        //Affiche le nom des parcelles
        affichage += "\n     Parcelle 4        Parcelle 5        Parcelle 6";     
        Console.WriteLine(affichage);
    }
}


/*Méthodes à mettre
Drainer : faire un truc proportionnel aux nombre de plantes, enlever un peu d'eau à chaque tour, se fait automatiquement à la fin du jeu
*/
