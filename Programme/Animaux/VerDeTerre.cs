public class VerDeTerre : Animaux 
{
    

    public VerDeTerre (int parcelleDepart, int emplacementDepart, Terrain terrainAnimal) : base (parcelleDepart,emplacementDepart, terrainAnimal)
    {
        NomAnimal="Ver De Terre";
    }

    public override void Action(int parcelleDepart, int emplacementDepart) //les ver de terre augmentent l'humidité de la parcelle 
    {

    }
}