public class Bamboo : PlantesDecoratives
{
    public Bamboo(Parcelle parcellePlante) : base(parcellePlante)
    {
        ImagesPlante = new List<string> {" 🍂 ","🎍.0","🎍.1","🎍.2","🎍.3"};
        NomPlante = "Bamboo";
        //SaisonSemis = juiillet, aout, septembre, octobre, 
        BesoinHumidite = 0.3;
        BesoinLuminosite = 0.2;
        //MaladiesContractables = (....)
        TemperaturePrefereeMin = 5;
        TemperaturePrefereeMax = 25;
        NatureCommercialisable = true;  
    }
}