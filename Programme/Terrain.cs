class Terrain
{
    public string NumTerrain {get;set;}
    public int HumiditeTerrain {get; set;} //Allant de 0(très sec) à 10(très humide)
    public List<Parcelle> SousTerrains {get; set;}
    public string TypeTerrain {get; set;} //Determine si le terrain est argileux, cailloux, tourbière ou mare.

    public Terrain(string numTerrain, string typeTerrain)
    {
        //Lorsque l'on initalise un terrain, il est vide 'o'.
        List<char> charInitiaux = new List<char> {'o', 'o', 'o', 'o', 'o', 'o'};
        SousTerrains = new List<Parcelle> {};
        for (int i=0; i<6; i++)
        {
            Parcelle parcelle = new Parcelle($"numTerrain{+i}", charInitiaux);
            SousTerrains.Add(parcelle);
        }
        HumiditeTerrain = 5; //A l'initalisation, l'humidité est par défaut à 5.
        NumTerrain = numTerrain;
        TypeTerrain = typeTerrain;
    }
    public override string ToString()
    {
        string affichageSousTerrain = " ";
        int index=1;
        foreach (var item in SousTerrains)
        {
            string elementsListe = " ";
            foreach (var element in item.Emplacements)
            {
                elementsListe += element;
            }
            affichageSousTerrain += $"\n    Parcelle {index} : {elementsListe}";
            index++;
        }
        string affichage = $"=== TERRAIN === {NumTerrain}\n     -> Type : {TypeTerrain}\n     -> Humidité : {HumiditeTerrain} \n Voici le détail des parcelles : {affichageSousTerrain}";
        return affichage;
    }
}

/*Méthodes à mettre

Drainer : faire un truc proportionnel aux nombre de plantes, enlever un peu d'eau à chaque tour, se fait automatiquement à la fin du jeu


 - Actions du joueur -
Arroser :
Traiter :
Ombrager :
Proteger :


*/