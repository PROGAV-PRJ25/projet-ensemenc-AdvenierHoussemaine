public class Nenuphar : PlantesDecoratives
{
    public Nenuphar (Parcelle parcellePlante) : base(parcellePlante)
    {
        ImagesPlante = new List<string> {"🍂","🪷.0","🪷.1","🪷.2","🪷.3"};
        NomPlante = "Nenuphar";
        SurfaceNecessaire = 1;
        //SaisonSemis = fevrier, mars, avril
        BesoinHumidite = 1;
        BesoinLuminosite = 0.6;
        //MaladiesContractables = (....)
        TemperaturePrefereeMin = 10;
        TemperaturePrefereeMax = 20;
        NatureCommercialisable = false;
    }
}