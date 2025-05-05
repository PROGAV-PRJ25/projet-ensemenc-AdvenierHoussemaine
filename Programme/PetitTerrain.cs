class petitTerrain : Terrain
{
    List<char> Emplacements {get; set;} 

    public PetitTerrain(int humidite, int numTerrain, List<char> emplacements, string type) : base(HumiditeTerrain, numTerrain, TypeTerrain)
    {
        Emplacements = emplacements;
    }
}