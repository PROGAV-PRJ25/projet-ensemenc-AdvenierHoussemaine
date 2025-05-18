public class Carotte: PlantesDecoratives
{
    public Carotte(Parcelle parcellePlante) : base(parcellePlante)
    {
        ImagesPlante = new List<string> {" 🍂 ","🥕.0","🥕.1","🥕.2","🥕.3"};
        NomPlante = "Carotte";
        //SaisonSemis = novembre, decembre, octobre, janvier, fevrier
        BesoinHumidite = 0.3;
        BesoinLuminosite = 0.1;
        TemperaturePrefereeMin = 0;
        TemperaturePrefereeMax = 15;
        NombreProduits = 2;
    }
}