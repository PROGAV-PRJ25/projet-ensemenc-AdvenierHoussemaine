public class Tulipe : PlantesDecoratives
{
    public Tulipe(Parcelle parcellePlante) : base(parcellePlante)
    {
        ImagesPlante = new List<string> {" 🍂 ","🌷.0","🌷.1","🌷.2","🌷.3"};
        NomPlante = "Tulipe";
        //SaisonSemis = janvier, fevrier, mars
        BesoinHumidite = 0.4;
        BesoinLuminosite = 0.8;
        //MaladiesContractables = (....)
        TemperaturePrefereeMin = 5;
        TemperaturePrefereeMax = 15;
        NatureCommercialisable = true;  
    }
}