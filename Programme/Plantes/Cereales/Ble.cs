//Plante que l'on plante en Mai, Juin ou Novembre, Octobre.

public class Ble : Cereales
{
    public Ble(Terrain terrainPlante, int positionParcelle)
    {
        ImagesPlante = new List<string> {"🍂","🌾.0","🌾.1","🌾.2","🌾.3"};
        TerrainPlante = terrainPlante;
        ParcellePlante = TerrainPlante.Parcelles[positionParcelle]; //Inidique sur quelle parcelle du terrain se situe la plante.
        NomPlante = "Blé";
        NombreProduits = 5;
        SurfaceNecessaire = 1;
        //SaisonSemis = octobren novembre, mai, juin
        BesoinHumidite = 0.3;
        BesoinLuminosite = 0.6;
        DureeDeMaturation = 6;
        //MaladiesContractables = (....)
        TemperaturePrefereeMin = 10;
        TemperaturePrefereeMax = 20;    
    }
}