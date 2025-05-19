public class Abeille : Animaux
{
    public Abeille(int parcelleDepart, int emplacementDepart, Terrain terrainAnimal) : base(parcelleDepart, emplacementDepart, terrainAnimal)
    {
        NomAnimal = "Abeille";
    }

    public override void Action(int parcelleDepart, int emplacementDepart) //les abeilles augmentent la vitesse de croissance 
    {
        for (int i = 0; i < 12; i++)
        {
            Plante planteAvecAbeille = TerrainAnimal.Parcelles[parcelleDepart].Plantes[i];
            //verifier que ce n'est pas la plante null
            if (planteAvecAbeille.NomPlante != "null" || planteAvecAbeille.VitesseCroissance <= 0.9)
                planteAvecAbeille.VitesseCroissance += 0.1;
            //jouer sur ces la maturation , possible de complexifier avec la polenisation 
        }
    }
    
    public override string ToString()
    {
        return $"Des abeilles ont augmenté le bien être des plantes de la parcelle {ParcellePositionAnimal +1} . \n Leur vitesse de croissance c'est vu augmenté ";
    }
}