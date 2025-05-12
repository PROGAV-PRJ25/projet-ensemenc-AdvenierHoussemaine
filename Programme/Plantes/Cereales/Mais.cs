//Saison de semis = mars/avril/mai
public class Mais : Cereales
{
    public Mais(Terrain terrainPlante, int positionParcelle)
    {
        ImagesPlante = new List<string> {"🍂","🌽.0","🌽.1","🌽.2","🌽.3"};
        TerrainPlante = terrainPlante;
        ParcellePlante = TerrainPlante.Parcelles[positionParcelle]; //Inidique sur quelle parcelle du terrain se situe la plante.
        NomPlante = "Mais";
        NombreProduits = 3;
        SurfaceNecessaire = 1;
        //SaisonSemis = mars, avril, mai
        BesoinHumidite = 0.5;
        BesoinLuminosite = 0.5;
        DureeDeMaturation = 3;
        //MaladiesContractables = (....)
        TemperaturePrefereeMin = 10;
        TemperaturePrefereeMax = 20;  
    }
}
