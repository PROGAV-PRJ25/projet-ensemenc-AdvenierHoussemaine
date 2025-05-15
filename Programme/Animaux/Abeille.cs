public class Abeille : Animaux 
{
    

    public Abeille (int parcelleDepart, int emplacementDepart, Terrain terrainAnimal) : base (parcelleDepart,emplacementDepart, terrainAnimal)
    {
        NomAnimal="Abeille";
    }

    public override void Action(int parcelleDepart, int emplacementDepart) //les abeilles augmentent la vitesse de croissance 
    {

    }
}