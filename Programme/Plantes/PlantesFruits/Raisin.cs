public class Raisin: PlantesDecoratives
{
    public Raisin(Parcelle parcellePlante) : base(parcellePlante)
    {
        ImagesPlante = new List<string> {"🍂","🍇.0","🍇.1","🍇.2","🍇.3"};
        NomPlante = "Raisin";
        //SaisonSemis = avril, mai, juin
        BesoinHumidite = 0.4;
        BesoinLuminosite = 0.4;
        TemperaturePrefereeMin = 7;
        TemperaturePrefereeMax = 20;
        NombreProduits = 5;
    }
}