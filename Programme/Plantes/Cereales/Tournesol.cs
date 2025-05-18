//Planter en avril/mai/juin
using System.ComponentModel;
using System.Net.Mail;

public class Tournesol : Cereales
{
    public Tournesol(Parcelle parcellePlante) : base(parcellePlante)
    {
        ImagesPlante = new List<string> {" 🍂 ","🌻.0","🌻.1","🌻.2","🌻.3"};
        NomPlante = "Tournesol";
        NombreProduits = 1;
        //SaisonSemis = avril, mai, juin
        BesoinHumidite = 0.4;
        BesoinLuminosite = 0.8;
        DureeDeMaturation = 4;
        //MaladiesContractables = (....)
        TemperaturePrefereeMin = 10;
        TemperaturePrefereeMax = 20;     
    }
}

