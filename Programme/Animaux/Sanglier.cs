public class Sanglier : Animaux
{
    public Sanglier(int parcelleDepart, int emplacementDepart, Terrain terrainAnimal) : base(parcelleDepart, emplacementDepart, terrainAnimal)
    {
        NomAnimal = "Sanglier";
    }

    public override void Action(int parcelleDepart, int emplacementDepart) //le sanglier piétine les plantes 
    {
        //possible de faire que les nénuphare et les cactus le bloque
        for (int i = 0; i < 12; i++)
        {
            TerrainAnimal.Parcelles[parcelleDepart].Plantes[i].VitesseCroissance = -1;
        }
    }
    
    public override string ToString()
    {
        return $"Un sanglier c'est introduit pendant une nuit dans la parcelle {ParcellePositionAnimal +1} . \n Il a pietiné toute les plantes présentes ";
    }
}