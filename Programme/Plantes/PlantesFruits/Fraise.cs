public class Fraise: PlantesDecoratives
{
    public Fraise(Parcelle parcellePlante) : base(parcellePlante)
    {
        ImagesPlante = new List<string> {"🍂","🍓.0","🍓.1","🍓.2","🍓.3"};
        NomPlante = "Fraise";
        //SaisonSemis = avril, mai, juin
        BesoinHumidite = 0.6;
        BesoinLuminosite = 0.8;
        TemperaturePrefereeMin = 10;
        TemperaturePrefereeMax = 25;
        NombreProduits = 4;
    }
}