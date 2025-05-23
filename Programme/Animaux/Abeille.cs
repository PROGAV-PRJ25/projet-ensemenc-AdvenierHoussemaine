public class Abeille : Animaux
{
    public Abeille(int parcelleDepart, Terrain terrainAnimal) : base(parcelleDepart, terrainAnimal)
    {
        NomAnimal = "Abeille";
    }

    public override void Action(int parcelleDepart) //les abeilles augmentent la vitesse de croissance 
    {
        Console.WriteLine("\n~~~ 🐝 ~~~");
        for (int i = 0; i < 12; i++)
        {   
            Plante planteAvecAbeille = TerrainAnimal.Parcelles[parcelleDepart].Plantes[i];
            //verifier que ce n'est pas la plante null
            if (!(planteAvecAbeille is PlanteNull) && !(planteAvecAbeille is PlanteInvasive) && planteAvecAbeille.NiveauMaturation <= 3 && planteAvecAbeille.NiveauMaturation >= 0)
            {
                planteAvecAbeille.NiveauMaturation += 1;
                TerrainAnimal.Parcelles[parcelleDepart].Emplacements[i] = planteAvecAbeille.ImagesPlante![planteAvecAbeille.NiveauMaturation];
            }
            //jouer sur ces la maturation , possible de complexifier avec la polenisation 
        }
        Console.WriteLine($"\n=> Des abeilles ont augmenté le bien être des plantes de la parcelle {ParcellePositionAnimal + 1}. \n Leur vitesse de croissance c'est vu augmenté ");
        System.Threading.Thread.Sleep(1500);
    }
    
    public override string ToString()
    {
        return $"Des abeilles ont augmenté le bien être des plantes de la parcelle {ParcellePositionAnimal +1} . \n Leur vitesse de croissance c'est vu augmenté ";
    }
}