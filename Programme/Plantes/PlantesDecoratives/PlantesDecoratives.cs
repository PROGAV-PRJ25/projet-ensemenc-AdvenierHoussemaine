public abstract class PlantesDecoratives : Plante
{
    
    public PlantesDecoratives(Parcelle parcellePlante) : base(parcellePlante)
    {
        DureeDeMaturation = 2;
        NombreProduits = 1;
        ValeurProduit = 4;
    }
    
}