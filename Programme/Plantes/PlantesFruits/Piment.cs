public class Piment: PlantesDecoratives
{
    public Piment(Parcelle parcellePlante) : base(parcellePlante)
    {
        ImagesPlante = new List<string> {" 🍂 ","🌶️.0","🌶️.1","🌶️.2","🌶️.3"};
        NomPlante = "Piment";
        //SaisonSemis = juillet, aout, septembre
        BesoinHumidite = 0.2;
        BesoinLuminosite = 0.8;
        TemperaturePrefereeMin = 15;
        TemperaturePrefereeMax = 35;
        NombreProduits = 2;
    }
}