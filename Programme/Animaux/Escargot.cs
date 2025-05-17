public class Escargot : Animaux 
{
    private bool terrainTropSec = false;

    public Escargot (int parcelleDepart, int emplacementDepart, Terrain terrainAnimal) : base (parcelleDepart,emplacementDepart, terrainAnimal)
    {
        NomAnimal="Escargot";
    }

    public override void Action(int parcelleDepart, int emplacementDepart) //les escargots mangent tout les fruits d'une parcelle 
    {
        if(TerrainAnimal.Parcelles[parcelleDepart].HumiditeParcelle>0.3) //on peut modifier la valeur mais c'est pour indiquer qu'il n'aiment pas quand c'est sec
        {
            for (int i = 0 ; i<12 ; i++)
            {
                if(TerrainAnimal.Parcelles[parcelleDepart].Plantes[i].NatureCommercialisable==true)//l'escargot se situe sur une plante avec quelque chose à manger
                {
                    //soit attaque nombreProduit ou les images 
                }
            }
        }
        else
        {
            terrainTropSec = true;
            Console.WriteLine("il fait trop sec pour que des escargots viennent nuire");
        }
    }
    public override string ToString()
    {
        if (terrainTropSec==false)
        {
            return $"Des escargots ont mangé ce qui était comestible dans la parcelle {ParcellePositionAnimal +1} avant de partir. \n Elle contiens maintenant : ";
    
        }
        else 
        {
            return $"Des Escargots ont voulu manger dans la parcelle {ParcellePositionAnimal + 1} mais il fesait trop sec, elles sont alors repartis ";
        }
    }
}

// si c'est humide il vient 