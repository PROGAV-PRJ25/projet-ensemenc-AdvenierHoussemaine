public class TerrainRocheux : Terrain
{
    public TerrainRocheux(string numTerrain) : base (numTerrain)
    {
        TypeTerrain = "Rocheux";
    }
    public void ProtegerAvecLezards()
    {
        //Mettre des poissons qui enlèvent les parasites des plantes
    }
}