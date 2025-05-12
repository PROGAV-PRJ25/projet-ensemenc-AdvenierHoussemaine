/*Les parcelles sont des "sous-sterrains" dans les terrains. Il est possible de planter qu'un seul type de plante dans une parcelle.
  Donc, sur un terrain il peut y avoir au maximum 6 types de plantes.
  Le joueur ne peux exécuter une action sur une parcelle. Il doit faire son action sur tout le terrain.*/
public class Parcelle
{
    public List<string> Emplacements {get; set;} //Les emplacements sont les "unités d'espace" dans une parcelle. Il y en a 6 dans chaque parcelle.
    public string NumParcelle {get; set;}
    public List<Plante> Plantes {get; set;} //Repertorie les plantes dans la parcelle.

    public Parcelle(string numPetitTerrain, List<string> emplacements)
    {
        Emplacements = emplacements;
        NumParcelle = numPetitTerrain;
        Plantes = new List<Plante> {};
    }
}