public class VerDeTerre : Animaux 
{
    

    public VerDeTerre (int parcelleDepart, Terrain terrainAnimal) : base (parcelleDepart,terrainAnimal)
    {
        NomAnimal="Ver De Terre";
    }

    public override void Action(int parcelleDepart) //les ver de terre augmentent l'humidité de la parcelle 
    {
        Console.WriteLine("\n~~~ 🪱 ~~~");
        if (TerrainAnimal.Parcelles[parcelleDepart].AbsorbtionDeLeau <= 0.9)
        {
            TerrainAnimal.Parcelles[parcelleDepart].AbsorbtionDeLeau += 0.1;
        }
        Console.WriteLine($"\n=> Des vers de terre ont augmenté la capacité d'absorbtion de l'eau de la parcelle {ParcellePositionAnimal + 1} . \n Elle est maintenant de {TerrainAnimal.Parcelles[ParcellePositionAnimal].AbsorbtionDeLeau} ");
        System.Threading.Thread.Sleep(1500);
    }

    public override string ToString()
    {
        return $"Des vers de terre ont augmenté la capacité d'absorbtion de l'eau de la parcelle {ParcellePositionAnimal +1} . \n Elle est maintenant de {TerrainAnimal.Parcelles[ParcellePositionAnimal].AbsorbtionDeLeau} ";
    }
}