public class TerrainTourbiere : Terrain
{
    public TerrainTourbiere(string numTerrain, string typeTerrain) : base (numTerrain, typeTerrain)
    {
        TypeTerrain = "Tourbière";
    }

    public void ProtegerAvecPoissons()
    {
        //Mettre des poissons qui enlèvent les parasites des plantes
    }
}