public class Fraise: PlantesDecoratives
{
    public Fraise(Terrain terrainPlante, int positionParcelle)
    {
        ImagesPlante = new List<string> {"🍂","🍓.0","🍓.1","🍓.2","🍓.3"};
        TerrainPlante = terrainPlante;
        ParcellePlante = TerrainPlante.Parcelles[positionParcelle]; //Inidique sur quelle parcelle du terrain se situe la plante.
        NomPlante = "Fraise";
        //SaisonSemis = avril, mai, juin
        BesoinHumidite = 0.6;
        BesoinLuminosite = 0.8;
        TemperaturePrefereeMin = 10;
        TemperaturePrefereeMax = 25;
        NombreProduits = 4;
    }
}