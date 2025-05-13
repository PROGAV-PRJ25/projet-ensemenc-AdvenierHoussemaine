/*Les parcelles sont des "sous-terrains" dans les terrains.
  Les actions du joueur agissent que sur une parcelle.*/
public class Parcelle
{
    public List<string> Emplacements {get; set;} //Les emplacements sont les "unités d'espace" dans une parcelle. Il y en a 12 dans chaque parcelle.
    public int NumParcelle {get; set;}
    public double HumiditeParcelle {get; set;} //Allant de 0(très sec) à 1(très humide)
    public double EnsoleillementParcelle {get; set;} //Allant de 0(ombragé) à 1(plein soleil)
    public List<Plante> Plantes {get; set;} //Repertorie les plantes dans la parcelle.
    public Parcelle(int numPetitTerrain, List<string> emplacements)
    {
        Emplacements = emplacements;
        NumParcelle = numPetitTerrain;
        Plantes = new List<Plante> {};
    }

    public void Arroser()
    {
      //MODIFIER LA VALEUR DE L'HUMIDITE DU TERRAIN
      bool robustesse = true;
      int intensiteArrosage;
      do
      {
        Console.WriteLine("Vous avez choisi d'arroser votre parcelle.");
        Console.WriteLine("A quel point voulez-vous arroser vos plantes ? (Tappez 1 2 ou 3)");
        string input = Console.ReadLine()!;
        robustesse = int.TryParse(input, out intensiteArrosage); //Renvoie false si la valeur saisie n'est pas un entier.
        if (robustesse == true) //Va modofier la valeur de l'humidité si la valeur entrée est un entier.
        {
          intensiteArrosage = Convert.ToInt32(input);
          //Il y a trois intensités d'arrosage, le joueur peut tapper 1 2 ou 3.
          if (intensiteArrosage == 1) HumiditeParcelle += 0.1;
          else if (intensiteArrosage == 2) HumiditeParcelle += 0.2;
          else if (intensiteArrosage == 3) HumiditeParcelle += 0.3;
          else robustesse = false;
        }
        else robustesse = false;
      }while(robustesse == false);
    }
    public void Ombrager()
    {
      //MODIFIER LA VALEUR DE L'ENSOLEILLEMENT DU TERRAIN
      bool robustesse = true;
      do
      {
        Console.WriteLine("Vous avez choisi d'omrager votre terrain.");
        Console.WriteLine("Voulez-vous ombrager votre terrain ? Tappez o ou n.");
        string input = Console.ReadLine()!;
        robustesse = (input == "o" || input == "n"); //Renvoie false si la valeur saisie n'est o ou n.
        if (robustesse == true && input == "o") //Va modifier la valeur de l'ensoleillement si la valeur entrée est o ou n.
        {
          EnsoleillementParcelle -= 0.3;
        }
        else robustesse = false;
      }while(robustesse == false);
    }
    public void TraiterMaladie()
    {
        Console.WriteLine("Vous avez choisi de traiter les plantes de votre terrain.");
        //EN CAS DE MALADIE, ENLEVE LES DOMMAGES CAUSEES A LA PLANTE.
         foreach (var plante in Plantes)
            {
                plante.VitesseCroissance += 0.4; //Une maladie inflige un dégat de 0.5 à la plante, la traiter permet de récupérer 0.1 points de croissance.
            }
        //Si y'a des animaux gentils, ca les fait partir.
    }
    public void Desherber()
    {
      int index = 0; //On veut récupérer l'indice des itérations emplacement.
      foreach(var emplacement in Emplacements)
      {
        if (emplacement == "🌱") 
        {
          Emplacements[index] = "🟤";
          index++;
        }
      } 
    }
}
