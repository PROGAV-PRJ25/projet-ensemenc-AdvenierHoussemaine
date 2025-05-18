public abstract class PlantesFruits : Plante
{
    
    public PlantesFruits(Parcelle parcellePlante) : base(parcellePlante)
    {
        DureeDeMaturation = 4;
        NatureCommercialisable = true;
        ValeurProduit = 1;
    }
    
}