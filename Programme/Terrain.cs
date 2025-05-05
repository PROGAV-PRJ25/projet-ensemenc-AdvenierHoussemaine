abstract class Terrain
{
    public int NumTerrain {get;set;}
    public int HumiditeTerrain {get; set;}
    public List<PetitTerrain> SousTerrains {get; set;}
    public string TypeTerrain {get; set;}

    public Terrain(int humidite, int numTerrain, List<PetitTerrain> sousTerrain, string type)
    {
        HumiditeTerrain = humidite;
        NumTerrain = numTerrain;
        SousTerrain = sousTerrains;
        TypeTerrain = type;
    }
    public override string ToString()
    {
        string affichage = $"=== TERRAIN === {NumTerrain}\n -> Humidité : {Humidité}";
        return affichage;
    }
}