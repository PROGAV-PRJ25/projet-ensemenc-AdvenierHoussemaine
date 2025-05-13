public class Nenuphar : PlantesDecoratives
{
    public Nenuphar (Terrain terrainPlante, int positionParcelle)
    {
        ImagesPlante = new List<string> {"🍂","🪷.0","🪷.1","🪷.2","🪷.3"};
        TerrainPlante = terrainPlante;
        ParcellePlante = TerrainPlante.Parcelles[positionParcelle]; //Inidique sur quelle parcelle du terrain se situe la plante.
        NomPlante = "Nénuphar";
        SurfaceNecessaire = 1;
        //SaisonSemis = fevrier, mars, avril
        BesoinHumidite = 1;
        BesoinLuminosite = 0.6;
        //MaladiesContractables = (....)
        TemperaturePrefereeMin = 10;
        TemperaturePrefereeMax = 20;
        NatureCommercialisable = false;
    }
}