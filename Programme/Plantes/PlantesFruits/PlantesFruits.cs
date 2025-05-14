public abstract class PlantesFruits : Plante
{
    
    public PlantesFruits(Parcelle parcellePlante) : base(parcellePlante)
    {
        SurfaceNecessaire = 1;
        //MaladiesContractables = (....)
        DureeDeMaturation = 4;
        NatureCommercialisable = true;
        ValeurProduit = 1;
    }
    
}