//Saison de semis = mars/avril/mai
public class Mais : Cereales
{
    public Mais(Parcelle parcellePlante) : base(parcellePlante)
    {
        ImagesPlante = new List<string> {"🍂","🌽.0","🌽.1","🌽.2","🌽.3"};
        NomPlante = "Mais";
        NombreProduits = 3;
        SurfaceNecessaire = 1;
        //SaisonSemis = mars, avril, mai
        BesoinHumidite = 0.5;
        BesoinLuminosite = 0.5;
        DureeDeMaturation = 3;
        //MaladiesContractables = (....)
        TemperaturePrefereeMin = 10;
        TemperaturePrefereeMax = 20;  
    }
}
