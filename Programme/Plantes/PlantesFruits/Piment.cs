public class Piment: PlantesDecoratives
{
    public Piment(Terrain terrainPlante, int positionParcelle)
    {
        ImagesPlante = new List<string> {"🍂","🌶️.0","🌶️.1","🌶️.2","🌶️.3"};
        TerrainPlante = terrainPlante;
        ParcellePlante = TerrainPlante.Parcelles[positionParcelle]; //Inidique sur quelle parcelle du terrain se situe la plante.
        NomPlante = "Piment";
        //SaisonSemis = juillet, aout, septembre
        BesoinHumidite = 0.2;
        BesoinLuminosite = 0.8;
        TemperaturePrefereeMin = 15;
        TemperaturePrefereeMax = 35;
        NombreProduits = 2;
    }
}