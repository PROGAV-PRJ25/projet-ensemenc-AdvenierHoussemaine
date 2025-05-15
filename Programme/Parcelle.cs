/*Les parcelles sont des "sous-terrains" dans les terrains.
  Les actions du joueur agissent que sur une parcelle.*/
using System.Runtime.CompilerServices;

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

    public void Planter(Parcelle parcelle, int positionParcelle)
    { 
      bool robustessePlanter = false;
      do
      {
        Console.WriteLine("Quelle plante voulez-vous planter ? \n Copiez-collez l'emoji : \n  -Décoratives : 🎍 🌵 🪷 🌷\n -Céréales : 🌾 🌽 🌻 \n -Fruits : 🍇 🌶️ 🍓 🥕");
        string input = Console.ReadLine()!;
        switch(input)
        {
          case "🎍":
            Bamboo bamboo = new Bamboo(parcelle);
            parcelle.Emplacements.Add(bamboo.ImagesPlante![1]); //Ajoute l'image à l'affichage
            parcelle.Plantes[positionParcelle] = bamboo;
            robustessePlanter = true;
            break;
          case "🌵":
            Cactus cactus = new Cactus(parcelle);
            parcelle.Emplacements.Add(cactus.ImagesPlante![1]); //Ajoute l'image à l'affichage
            //Voir comment ajouter à la liste de plantes. -- voir si c'est nécessaire ou si on utilise que les images.
            robustessePlanter = true;
            break;
          case "🪷":
            Nenuphar nenuphar = new Nenuphar(parcelle);
            parcelle.Emplacements.Add(nenuphar.ImagesPlante![1]); //Ajoute l'image à l'affichage
            //Voir comment ajouter à la liste de plantes. -- voir si c'est nécessaire ou si on utilise que les images.
            robustessePlanter = true;
            break;
          case "🌷":
            Tulipe tulipe = new Tulipe(parcelle);
            parcelle.Emplacements.Add(tulipe.ImagesPlante![1]); //Ajoute l'image à l'affichage
            //Voir comment ajouter à la liste de plantes. -- voir si c'est nécessaire ou si on utilise que les images.
            robustessePlanter = true;
            break;
          case "🌾":
            Ble ble = new Ble(parcelle);
            parcelle.Emplacements.Add(ble.ImagesPlante![1]); //Ajoute l'image à l'affichage
            //Voir comment ajouter à la liste de plantes. -- voir si c'est nécessaire ou si on utilise que les images.
            robustessePlanter = true;
            break;
          case "🌽":
            Mais mais = new Mais(parcelle);
            parcelle.Emplacements.Add(mais.ImagesPlante![1]); //Ajoute l'image à l'affichage
            //Voir comment ajouter à la liste de plantes. -- voir si c'est nécessaire ou si on utilise que les images.
            robustessePlanter = true;
            break;
          case "🌻":
            Tournesol tournesol = new Tournesol(parcelle);
            parcelle.Emplacements.Add(tournesol.ImagesPlante![1]); //Ajoute l'image à l'affichage
            //Voir comment ajouter à la liste de plantes. -- voir si c'est nécessaire ou si on utilise que les images.
            robustessePlanter = true;
            break;
          case "🥕":
            Carotte carotte = new Carotte(parcelle);
            parcelle.Emplacements.Add(carotte.ImagesPlante![1]); //Ajoute l'image à l'affichage
            //Voir comment ajouter à la liste de plantes. -- voir si c'est nécessaire ou si on utilise que les images.
            robustessePlanter = true;
            break;
          case "🍓":
            Fraise fraise = new Fraise(parcelle);
            parcelle.Emplacements.Add(fraise.ImagesPlante![1]); //Ajoute l'image à l'affichage
            //Voir comment ajouter à la liste de plantes. -- voir si c'est nécessaire ou si on utilise que les images.
            robustessePlanter = true;
            break;
          case "🌶️":
            Piment piment = new Piment(parcelle);
            parcelle.Emplacements.Add(piment.ImagesPlante![1]); //Ajoute l'image à l'affichage
            //Voir comment ajouter à la liste de plantes. -- voir si c'est nécessaire ou si on utilise que les images.
            robustessePlanter = true;
            break;
          case "🍇":
            Raisin raisin = new Raisin(parcelle);
            parcelle.Emplacements.Add(raisin.ImagesPlante![1]); //Ajoute l'image à l'affichage
            //Voir comment ajouter à la liste de plantes. -- voir si c'est nécessaire ou si on utilise que les images.
            robustessePlanter = true;
            break;
          default :
            robustessePlanter = false;
            Console.WriteLine("Choissiez une plante existante.");
            break;
        }
      }while(robustessePlanter == false);
        
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
        if (robustesse == true) //Va modifier la valeur de l'humidité si la valeur entrée est un entier.
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
        robustesse = (input == "o" || input == "n"); //Renvoie false si la valeur saisie n'est pas o ou n.
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
    }
    public void Desherber()
    {
      int index = 0; //On veut récupérer l'indice des itérations emplacement.
      foreach(var emplacement in Emplacements)
      {
        if (emplacement == "🌱" || emplacement == "🍂") 
        {
          Emplacements[index] = "🟤";
          index++;
        }
      } 
    }

}
