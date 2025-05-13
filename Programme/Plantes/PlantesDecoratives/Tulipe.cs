public class Tulipe : PlantesDecoratives
{
    public Tulipe(Terrain terrainPlante, int positionParcelle)
    {
        ImagesPlante = new List<string> {"🍂","🌷.0","🌷.1","🌷.2","🌷.3"};
        TerrainPlante = terrainPlante;
        ParcellePlante = TerrainPlante.Parcelles[positionParcelle]; //Inidique sur quelle parcelle du terrain se situe la plante.
        NomPlante = "Tulipe";
        SurfaceNecessaire = 1;
        //SaisonSemis = janvier, fevrier, mars
        BesoinHumidite = 0.4;
        BesoinLuminosite = 0.8;
        //MaladiesContractables = (....)
        TemperaturePrefereeMin = 5;
        TemperaturePrefereeMax = 15;
        NatureCommercialisable = true;  
    }
}