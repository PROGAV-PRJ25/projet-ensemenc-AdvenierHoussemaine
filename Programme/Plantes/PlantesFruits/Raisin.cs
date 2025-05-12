public class Raisin: PlantesDecoratives
{
    public Raisin(Terrain terrainPlante, int positionParcelle)
    {
        ImagesPlante = new List<string> {"🍂","🍇.0","🍇.1","🍇.2","🍇.3"};
        TerrainPlante = terrainPlante;
        ParcellePlante = TerrainPlante.Parcelles[positionParcelle]; //Inidique sur quelle parcelle du terrain se situe la plante.
        NomPlante = "Raisin";
        //SaisonSemis = avril, mai, juin
        BesoinHumidite = 0.4;
        BesoinLuminosite = 0.4;
        TemperaturePrefereeMin = 7;
        TemperaturePrefereeMax = 20;
        NombreProduits = 5;
    }
}