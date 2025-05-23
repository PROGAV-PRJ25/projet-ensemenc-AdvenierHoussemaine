using System.Runtime.Serialization;
public abstract class Animaux
{
    protected int ParcellePositionAnimal { get; set; }
    protected string? NomAnimal {get; set;} = "";

    protected Terrain TerrainAnimal {get; set;}
    public Animaux(int parcelleDepart, Terrain terrainAnimal)
    {
        ParcellePositionAnimal = parcelleDepart;
        TerrainAnimal = terrainAnimal;

    }

    //Methode action qu'on overide 
    public abstract void Action(int parcelleDepart);
    
    
    
}