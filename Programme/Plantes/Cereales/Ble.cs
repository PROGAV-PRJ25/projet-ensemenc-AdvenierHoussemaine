//Plante que l'on plante en Mai, Juin ou Novembre, Octobre.

public class Ble : Cereales
{
    public Ble(Parcelle parcellePlante) : base(parcellePlante)
    {
        ImagesPlante = new List<string> {" 🍂 ","🌾.0","🌾.1","🌾.2","🌾.3"};
        NomPlante = "Ble";
        NombreProduits = 5;
        //SaisonSemis = octobren novembre, mai, juin
        BesoinHumidite = 0.3;
        BesoinLuminosite = 0.6;
        DureeDeMaturation = 6;
        //MaladiesContractables = (....)
        TemperaturePrefereeMin = 10;
        TemperaturePrefereeMax = 20;    
    }
}