using System.Runtime.Serialization;

public abstract class Animaux
{
    public int ParcellePositionAnimal { get; set; }

    public int EmplacementPositionAnimal { get; set; }
    public string? NomAnimal {get; set;} = "";

    public Terrain TerrainAnimal {get; set;}
    public Animaux(int parcelleDepart, int emplacementDepart, Terrain terrainAnimal)
    {
        ParcellePositionAnimal = parcelleDepart;
        EmplacementPositionAnimal = emplacementDepart;
        TerrainAnimal = terrainAnimal;

    }

    //Methode action qu'on overide 
    public abstract void Action(int parcelleDepart, int emplacementDepart);
    
    
    
}