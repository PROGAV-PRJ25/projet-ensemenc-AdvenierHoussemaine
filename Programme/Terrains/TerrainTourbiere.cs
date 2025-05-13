public class TerrainTourbiere : Terrain
{
    public TerrainTourbiere(string numTerrain) : base (numTerrain)
    {
        TypeTerrain = "Tourbière";
    }

    public void ProtegerAvecPoissons()
    {
        //Mettre des poissons qui enlèvent les parasites des plantes
    }
}