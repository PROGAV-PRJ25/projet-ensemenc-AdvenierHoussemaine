abstract class Terrain
{
    public int NumTerrain {get;set;}
    public int HumiditeTerrain {get; set;} //Allant de 0(très sec) à 10(très humide)
    public List<PetitTerrain> SousTerrains {get; set;}
    public string TypeTerrain {get; set;} //Determine si le terrain est argileux, cailloux, tourbière ou mare.

    public Terrain(int numTerrain, string type)
    {
        //Lorsque l'on initalise un terrain, il est vide 'o'.
        List<char> charInitiaux = new List<char> ['o', 'o', 'o', 'o', 'o', 'o'];
        for (int i=0; i<6; i++)
        {
            PetitTerrain petitTerrain = new PetitTerrain(charInitiaux);
            SousTerrains[i] = petitTerrain;
        }
        HumiditeTerrain = 5; //A l'initalisation, l'humidité est par défaut à 5.
        NumTerrain = numTerrain;
        TypeTerrain = type;
    }
    public override string ToString()
    {
        string affichageSousTerrain = " ";
        int index=1;
        foreach (var item in SousTerrains)
        {
            affichageSousTerrain += $"\n Parcelle {index} : {item}";
            index++;
        }
        string affichage = $"=== TERRAIN === {NumTerrain}\n -> Type : {TypeTerrain}\n   -> Humidité : {Humidité} \n Voici le détail des parcelles : {affichageSousTerrain}";
        return affichage;
    }
}