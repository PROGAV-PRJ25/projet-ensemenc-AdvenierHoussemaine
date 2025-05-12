public class TerrainSableux : Terrain
{
    public TerrainSableux(string numTerrain) : base (numTerrain)
    {       
        TypeTerrain = "Sableux";
    }
    public void ProtegerAvecBarriere()
    {
        //Mettre des poissons qui enlèvent les parasites des plantes
    }
}