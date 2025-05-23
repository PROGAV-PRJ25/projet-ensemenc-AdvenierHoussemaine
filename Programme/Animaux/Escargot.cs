
public class Escargot : Animaux 
{
    private bool parcelleTropSec = false;

    public Escargot (int parcelleDepart, Terrain terrainAnimal) : base (parcelleDepart, terrainAnimal)
    {
        NomAnimal="Escargot";
    }

    public override void Action(int parcelleDepart) //les escargots mangent tout les fruits d'une parcelle 
    {
        Console.WriteLine("\n~~~ 🐌 ~~~");
        if (TerrainAnimal.Parcelles[parcelleDepart].HumiditeParcelle > 0.3) //on peut modifier la valeur mais c'est pour indiquer qu'il n'aiment pas quand c'est sec
        {
            for (int i = 0; i < 12; i++)
            {
                if (TerrainAnimal.Parcelles[parcelleDepart].Plantes[i].NatureCommercialisable == true)//l'escargot se situe sur une plante avec quelque chose à manger
                {
                    //si la plante n'est pas morte l'escargot mange et fait diminuer le niveau de maturation
                    if (TerrainAnimal.Parcelles[parcelleDepart].Plantes[i].NiveauMaturation > 0)
                    {
                        PlanteNull PlanteNull = new PlanteNull(TerrainAnimal.Parcelles[0]);
                        TerrainAnimal.Parcelles[parcelleDepart].Emplacements[i] = " 🟤 ";
                        TerrainAnimal.Parcelles[parcelleDepart].Plantes[i] = PlanteNull;
                        Console.WriteLine($"Des escargots ont mangés les plantes dans la parcelle {parcelleDepart + 1} à l'emplacement {i + 1}");
                    }
                }
            }
        }
        else
        {
            parcelleTropSec = true;
            Console.WriteLine("Il fait trop sec pour que des escargots viennent nuire");
        }
        if (parcelleTropSec == false)
        {
            Console.WriteLine($"\n=> Des escargots ont mangé ce qui était comestible dans la parcelle {ParcellePositionAnimal + 1} avant de partir. \n Elle contient maintenant : ");
            System.Threading.Thread.Sleep(1500);

        }
        else
        {
            Console.WriteLine($"\n=> Des Escargots ont voulu manger dans la parcelle {ParcellePositionAnimal + 1} mais il faisait trop sec, ils sont alors repartis ");
            System.Threading.Thread.Sleep(1500);
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



