class PetitTerrain : Terrain
{
    List<char> Emplacements {get; set;} 

    public PetitTerrain(int numTerrain, string type, List<char> emplacements) : base(numTerrain, TypeTerrain)
    {
        Emplacements = emplacements;
    }
}