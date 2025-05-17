public class Abeille : Animaux 
{
    

    public Abeille (int parcelleDepart, int emplacementDepart, Terrain terrainAnimal) : base (parcelleDepart,emplacementDepart, terrainAnimal)
    {
        NomAnimal="Abeille";
    }

    public override void Action(int parcelleDepart, int emplacementDepart) //les abeilles augmentent la vitesse de croissance 
    {
        for(int i=0, i<12, i++)
        {
            //jouer sur ces valeurs possible de complexifier avec la polenisation 
            TerrainAnimal.Parcelles[parcelleDepart].Plantes[i].VitesseCroissance
            TerrainAnimal.Parcelles[parcelleDepart].Plantes[i].DureeDeMaturation 
        }
    }
}