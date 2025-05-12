public class Bamboo : PlantesDecoratives
{
    public Bamboo(Terrain terrainPlante, int positionParcelle)
    {
        ImagesPlante = new List<string> {"🍂","🎍.0","🎍.1","🎍.2","🎍.3"};
        TerrainPlante = terrainPlante;
        ParcellePlante = TerrainPlante.Parcelles[positionParcelle]; //Inidique sur quelle parcelle du terrain se situe la plante.
        NomPlante = "Bamboo";
        SurfaceNecessaire = 3;
        //SaisonSemis = juiillet, aout, septembre, octobre, 
        BesoinHumidite = 0.3;
        BesoinLuminosite = 0.2;
        //MaladiesContractables = (....)
        TemperaturePrefereeMin = 5;
        TemperaturePrefereeMax = 25;
        NatureCommercialisable = true;  
    }
}