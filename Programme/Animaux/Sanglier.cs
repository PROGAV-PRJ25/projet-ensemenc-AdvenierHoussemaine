public class Sanglier : Animaux
{
    public Sanglier(int parcelleDepart, Terrain terrainAnimal) : base(parcelleDepart, terrainAnimal)
    {
        NomAnimal = "Sanglier";
    }

    public override void Action(int parcelleDepart) //le sanglier piétine les plantes 
    {
        Console.WriteLine("\n~~~ 🐗 ~~~");
        //possible de faire que les nénuphare et les cactus le bloque
        for (int i = 0; i < 12; i++)
        {
            TerrainAnimal.Parcelles[parcelleDepart].Plantes[i].VitesseCroissance = -1;
        }
        Console.WriteLine($"\n=> Un sanglier c'est introduit pendant une nuit dans la parcelle {ParcellePositionAnimal + 1} . \n Il a pietiné toute les plantes présentes ");
        System.Threading.Thread.Sleep(1500);
    }
    
    public override string ToString()
    {
        return $"Un sanglier c'est introduit pendant une nuit dans la parcelle {ParcellePositionAnimal +1} . \n Il a pietiné toute les plantes présentes ";
    }
}