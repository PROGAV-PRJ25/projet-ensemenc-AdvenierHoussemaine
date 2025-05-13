//Planter en avril/mai/juin
using System.ComponentModel;
using System.Net.Mail;

public class Tournesol : Cereales
{
    public Tournesol(Terrain terrainPlante, int positionParcelle)
    {
        ImagesPlante = new List<string> {"🍂","🌻.0","🌻.1","🌻.2","🌻.3"};
        TerrainPlante = terrainPlante;
        ParcellePlante = TerrainPlante.Parcelles[positionParcelle]; //Inidique sur quelle parcelle du terrain se situe la plante.
        NomPlante = "Tournesol";
        NombreProduits = 1;
        SurfaceNecessaire = 2;
        //SaisonSemis = avril, mai, juin
        BesoinHumidite = 0.4;
        BesoinLuminosite = 0.8;
        DureeDeMaturation = 4;
        //MaladiesContractables = (....)
        TemperaturePrefereeMin = 10;
        TemperaturePrefereeMax = 20;     
    }
}

