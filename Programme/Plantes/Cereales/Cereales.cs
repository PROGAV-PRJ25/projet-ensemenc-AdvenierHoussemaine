public abstract class Cereales : Plante
{ 
    public Cereales(Parcelle parcellePlante) : base(parcellePlante)
    {
        NatureCommercialisable = true;
        ValeurProduit = 2;
    } 
}
