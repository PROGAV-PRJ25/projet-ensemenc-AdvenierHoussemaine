//La planteNull sert à indiquer dans la liste de plantes de terrain qu'il n'y a pas de plante. Elle a des caractéristiques choisie de façon à ce qu'elle ne soit jamais en mauvais état( et donc n'influence pas l'état général du terrain).
public class PlanteNull: Plante
{
    public PlanteNull(Parcelle parcellePlante) : base(parcellePlante)
    {
        ImagesPlante = new List<string> {"🟤"};
        NomPlante = "null";
        NombreProduits = 0;
        SurfaceNecessaire = 1;
        //SaisonSemis = tt l'année
        BesoinHumidite = 0;
        BesoinLuminosite = 0;
        DureeDeMaturation = 0;
        //MaladiesContractables = (....)
        TemperaturePrefereeMin = -50;
        TemperaturePrefereeMax = 50;
        NatureCommercialisable = false;
    }
}