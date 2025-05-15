using System.Reflection;

public abstract class Terrain
{
    public double HumiditeTerrain {get; set;} //Allant de 0(très sec) à 1(très humide)
    public double AbsorbtionDeLeau {get; set;} // allant de 0(absorbe rien) à (1 absorbe pleinement)
    public double EnsoleillementTerrain {get; set;} //Allant de 0(ombragé) à 1(plein soleil)
    public List<Parcelle> Parcelles {get; set;} //Dans chaque terrain, il y a 12 emplacements pour planter des plantes. Dans chacune des ces parcelles, il y a 6 "unités d'espace".
    public string TypeTerrain {get; set;} = string.Empty; //Determine si le terrain est argileux, rocheux, tourbière ou sableux.

    public Terrain()
    {
        if (TypeTerrain == "Tourbière") {HumiditeTerrain = 1 ; AbsorbtionDeLeau = 0.1;}
        else if (TypeTerrain == "Argileux") {HumiditeTerrain = 0.4; AbsorbtionDeLeau = 0.3;}
        else if (TypeTerrain == "Sableux") {HumiditeTerrain = 0.7; AbsorbtionDeLeau = 0.5;}
        else if (TypeTerrain == "Rocheux") {HumiditeTerrain = 0.2; AbsorbtionDeLeau = 0.7;}
        //Lorsque l'on initalise un terrain, il est fait d'emplacements vides '🟤'.
        List<string> charInitiaux = new List<string> {"🟤", "🟤","🟤", "🟤", "🟤", "🟤", "🟤", "🟤","🟤", "🟤", "🟤", "🟤"};
        Parcelles  = new List<Parcelle> {};
        for (int i=0; i<6; i++)
        {
            Parcelle parcelle = new Parcelle(i+1, charInitiaux);
            parcelle.HumiditeParcelle = HumiditeTerrain;
            parcelle.EnsoleillementParcelle = EnsoleillementTerrain;
            Parcelles.Add(parcelle);
        }
        EnsoleillementTerrain = 0.5; //La valeur par défault au moment de l'initalisation.
    }

    public override string ToString()
    {   
        //if CLASSIQUE
        string affichageSousTerrain = " ";
        foreach (var parcelle in Parcelles)
        {
            string elementsListe = " ";
            foreach (var element in parcelle.Emplacements)
            {
                elementsListe += element;
            }
            affichageSousTerrain += $"\n    Parcelle {parcelle.NumParcelle} : {elementsListe}";
        }
        string affichage = $"=== TERRAIN=== \n     -> Type : {TypeTerrain}\n     -> Humidité : {HumiditeTerrain} \n Voici le détail des parcelles : {affichageSousTerrain}";
        return affichage;
        
        //if URGENCE
    }
}


/*Méthodes à mettre
Drainer : faire un truc proportionnel aux nombre de plantes, enlever un peu d'eau à chaque tour, se fait automatiquement à la fin du jeu
*/
