public class Escargot : Animaux 
{
    

    public Escargot (int parcelleDepart, int emplacementDepart, Terrain terrainAnimal) : base (parcelleDepart,emplacementDepart, terrainAnimal)
    {
        NomAnimal="Escargot";
    }

    public override void Action(int parcelleDepart, int emplacementDepart) //les 
    {
        if(TerrainAnimal.Parcelles[parcelleDepart]>0.3) //on peut modifier la valeur mais c'est pour indiquer qu'il n'aiment pas quand c'est sec
        {

        }
        else
        {
            Console.WriteLine("il fait trop sec pour que des escargots viennent nuire");
        }
    }
}

// si c'est humide il vient 