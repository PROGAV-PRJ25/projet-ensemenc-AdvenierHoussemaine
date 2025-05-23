public class Sanglier : Animaux
{
    public Sanglier(int parcelleDepart, Terrain terrainAnimal) : base(parcelleDepart, terrainAnimal)
    {
        NomAnimal = "Sanglier";
    }

    public override void Action(int parcelleDepart) //le sanglier piétine les plantes 
    {

        for (int i = 0; i < 12; i+=2)
        {
            PlanteNull PlanteNull = new PlanteNull(TerrainAnimal.Parcelles[0]);
            TerrainAnimal.Parcelles[parcelleDepart].Emplacements[i] = " 🟤 ";
            TerrainAnimal.Parcelles[parcelleDepart].Plantes[i] = PlanteNull;
        }
        Console.WriteLine($"\n=> Un sanglier c'est introduit pendant une nuit dans la parcelle {ParcellePositionAnimal + 1} . \n Il a pietiné la moitié des plantes présentes. ");
        System.Threading.Thread.Sleep(1500);
    }
    
    public override string ToString()
    {
        return $"Un sanglier c'est introduit pendant une nuit dans la parcelle {ParcellePositionAnimal +1} . \n Il a pietiné toute les plantes présentes ";
    }
}