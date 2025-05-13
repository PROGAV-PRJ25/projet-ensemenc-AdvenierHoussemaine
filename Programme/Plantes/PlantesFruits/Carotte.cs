public class Carotte: PlantesDecoratives
{
    public Carotte(Terrain terrainPlante, int positionParcelle)
    {
        ImagesPlante = new List<string> {"🍂","🥕.0","🥕.1","🥕.2","🥕.3"};
        TerrainPlante = terrainPlante;
        ParcellePlante = TerrainPlante.Parcelles[positionParcelle]; //Inidique sur quelle parcelle du terrain se situe la plante.
        NomPlante = "Carotte";
        //SaisonSemis = novembre, decembre, octobre, janvier, fevrier
        BesoinHumidite = 0.3;
        BesoinLuminosite = 0.1;
        TemperaturePrefereeMin = 0;
        TemperaturePrefereeMax = 15;
        NombreProduits = 2;
    }
}