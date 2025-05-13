public class Cactus : PlantesDecoratives
{
    public Cactus(Parcelle parcellePlante) : base(parcellePlante)
    {
        ImagesPlante = new List<string> {"🍂","🌵.0","🌵.1","🌵.2","🌵.3"};
        NomPlante = "Cactus";
        SurfaceNecessaire = 2;
        //SaisonSemis = mai, juin, juillet, aout, septembre
        BesoinHumidite = 0.1;
        BesoinLuminosite = 0.9;
        //MaladiesContractables = (....)
        TemperaturePrefereeMin = 15;
        TemperaturePrefereeMax = 35;
        NatureCommercialisable = true;  
    }
}