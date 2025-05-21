
public class Escargot : Animaux 
{
    private bool parcelleTropSec = false;

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
                    //si la plante n'est pas morte l'escargot mange et fait diminuer le niveau de maturation
                    if (TerrainAnimal.Parcelles[parcelleDepart].Plantes[i].NiveauMaturation>0)
                    {
                        TerrainAnimal.Parcelles[parcelleDepart].Plantes[i].NiveauMaturation--;
                        Console.WriteLine($"Des escargots ont mangés les plantes dans la parcelle {parcelleDepart +1} à l'emplacement {i +1}");
                    }
                }
            }
        }
        else
        {
            parcelleTropSec = true;
            Console.WriteLine("Il fait trop sec pour que des escargots viennent nuire");
        }
    }
    public override string ToString()
    {
        if (parcelleTropSec==false)
        {
            return $"Des escargots ont mangé ce qui était comestible dans la parcelle {ParcellePositionAnimal +1} avant de partir. \n Elle contiens maintenant : ";
    
        }
        else 
        {
            return $"Des Escargots ont voulu manger dans la parcelle {ParcellePositionAnimal + 1} mais il fesait trop sec, elles sont alors repartis ";
        }
    }
}



