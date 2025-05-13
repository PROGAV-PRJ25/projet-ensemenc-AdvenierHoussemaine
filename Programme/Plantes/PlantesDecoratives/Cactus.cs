public class Cactus : PlantesDecoratives
{
    public Cactus(Terrain terrainPlante, int positionParcelle)
    {
        ImagesPlante = new List<string> {"🍂","🌵.0","🌵.1","🌵.2","🌵.3"};
        TerrainPlante = terrainPlante;
        ParcellePlante = TerrainPlante.Parcelles[positionParcelle]; //Inidique sur quelle parcelle du terrain se situe la plante.
        NomPlante = "Cactus";
        SurfaceNecessaire = 2;
        //SaisonSemis = mai, juin, juillet, aout, septembre
        BesoinHumidite = 0.1;
        BesoinLuminosite = 0.9;
        //MaladiesContractables = (....)
        TemperaturePrefereeMin = 15;
        TemperaturePrefereeMax = 35;
        NatureCommercialisable = true;  
    }
}