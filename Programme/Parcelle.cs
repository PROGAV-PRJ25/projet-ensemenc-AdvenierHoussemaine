/*Les parcelles sont des "sous-terrains" dans les terrains.
  Les actions du joueur agissent que sur une parcelle.*/
using System.Runtime.CompilerServices;

public class Parcelle
{
    public string [] Emplacements {get; set;} //Les emplacements sont les "unités d'espace" dans une parcelle. Il y en a 12 dans chaque parcelle.
    public int NumParcelle {get; set;}
    public double AbsorbtionDeLeau {get; set;} // allant de 0(absorbe rien) à (1 absorbe pleinement)
    public double HumiditeParcelle {get; set;} //Allant de 0(très sec) à 1(très humide)
    public double EnsoleillementParcelle {get; set;} //Allant de 0(ombragé) à 1(plein soleil)
    public List<Plante> Plantes {get; set;} //Repertorie les plantes dans la parcelle.
    public Parcelle(int numPetitTerrain, string [] emplacements)
    {
        Emplacements = emplacements;
        NumParcelle = numPetitTerrain;
        Plantes = new List<Plante> (new PlanteNull[12]); //CHANGER ICI, CA INITIALISE PAS CORRECTEMENT! //On initialise avec 12 plantes null.
    }

    public void Planter(Parcelle parcelle, int positionParcelle)
    { 
      bool robustessePlanter = false;
      do
      {
        Console.WriteLine("Quelle plante voulez-vous planter ? \n\n  -Décoratives : bamboo🎍, cactus🌵 nénuphar🪷, tulipe🌷\n  -Céréales : blé🌾, mais🌽, tournesol🌻 \n  -Fruits : raisin🍇, piment🌶️, fraise🍓, carotte🥕");
        string input = Console.ReadLine()!.ToLower();
        switch(input)
        {
          case "bamboo":
            Bamboo bamboo = new Bamboo(parcelle);
            parcelle.Emplacements[positionParcelle] = bamboo.ImagesPlante![1]; //Ajoute l'image à l'affichage
            parcelle.Plantes[positionParcelle] = bamboo; //Ajouter la plante à la parcelle
            robustessePlanter = true;
            break;
          case "cactus":
            Cactus cactus = new Cactus(parcelle);
            parcelle.Emplacements[positionParcelle] = cactus.ImagesPlante![1]; //Ajoute l'image à l'affichage
            parcelle.Plantes[positionParcelle] = cactus; //Ajouter la plante à la parcelle
            robustessePlanter = true;
            break;
          case "nénuphar":
          case "nenuphar":
            Nenuphar nenuphar = new Nenuphar(parcelle);
            parcelle.Emplacements[positionParcelle] = nenuphar.ImagesPlante![1]; //Ajoute l'image à l'affichage
            parcelle.Plantes[positionParcelle] = nenuphar; //Ajouter la plante à la parcelle
            robustessePlanter = true;
            break;
          case "tulipe":
            Tulipe tulipe = new Tulipe(parcelle);
            parcelle.Emplacements[positionParcelle] = tulipe.ImagesPlante![1]; //Ajoute l'image à l'affichage
            parcelle.Plantes[positionParcelle] = tulipe; //Ajouter la plante à la parcelle
            robustessePlanter = true;
            break;
          case "blé":
          case "ble":
            Ble ble = new Ble(parcelle);
            parcelle.Emplacements[positionParcelle] = ble.ImagesPlante![1]; //Ajoute l'image à l'affichage
            parcelle.Plantes[positionParcelle] = ble; //Ajouter la plante à la parcelle
            robustessePlanter = true;
            break;
          case "mais":
          case "maïs":
            Mais mais = new Mais(parcelle);
            parcelle.Emplacements[positionParcelle] = mais.ImagesPlante![1]; //Ajoute l'image à l'affichage
            parcelle.Plantes[positionParcelle] = mais; //Ajouter la plante à la parcelle
            robustessePlanter = true;
            break;
          case "tournesol":
            Tournesol tournesol = new Tournesol(parcelle);
            parcelle.Emplacements[positionParcelle] = tournesol.ImagesPlante![1]; //Ajoute l'image à l'affichage
            parcelle.Plantes[positionParcelle] = tournesol; //Ajouter la plante à la parcelle
            robustessePlanter = true;
            break;
          case "carotte":
            Carotte carotte = new Carotte(parcelle);
            parcelle.Emplacements[positionParcelle] = carotte.ImagesPlante![1]; //Ajoute l'image à l'affichage
            parcelle.Plantes[positionParcelle] = carotte; //Ajouter la plante à la parcelle
            robustessePlanter = true;
            break;
          case "fraise":
            Fraise fraise = new Fraise(parcelle);
            parcelle.Emplacements[positionParcelle] = fraise.ImagesPlante![1]; //Ajoute l'image à l'affichage
            parcelle.Plantes[positionParcelle] = fraise; //Ajouter la plante à la parcelle
            robustessePlanter = true;
            break;
          case "piment":
            Piment piment = new Piment(parcelle);
            parcelle.Emplacements[positionParcelle] = piment.ImagesPlante![1]; //Ajoute l'image à l'affichage
            parcelle.Plantes[positionParcelle] = piment; //Ajouter la plante à la parcelle
            robustessePlanter = true;
            break;
          case "raisin":
            Raisin raisin = new Raisin(parcelle);
            parcelle.Emplacements[positionParcelle] = raisin.ImagesPlante![1]; //Ajoute l'image à l'affichage
            parcelle.Plantes[positionParcelle] = raisin; //Ajouter la plante à la parcelle
            robustessePlanter = true;
            break;
          default :
            robustessePlanter = false;
            Console.WriteLine("Choissiez une plante existante.");
            break;
        }
      }while(robustessePlanter == false);
        
    }
    public void InfiltrationDeLaPluie(Mois moisActuel)
    {//la pluviometrie est environ entre 5 et 10 cm par mois
      HumiditeParcelle += moisActuel.Pluviometrie* AbsorbtionDeLeau/10;
      if (HumiditeParcelle>1)
      {
        HumiditeParcelle=1;
      }
    }
    public void InfluenceSolei(Mois moisActuel)
    {
      // on initialise l'ensoleillement de la parcelle 
      EnsoleillementParcelle= moisActuel.Ensoleillement;
      //l'ensoleillement asseche la parcelle et reduit l'humidité de la parcelle
      HumiditeParcelle-=HumiditeParcelle*moisActuel.Ensoleillement; // si il y a beaucoup de solei et que la parcelle est très humide ca évaporera le plus 
      if (HumiditeParcelle<0)
      {
        HumiditeParcelle=0;
      }
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
          EnsoleillementParcelle -= 0.1; //au vue des valeurs de ensoleillement des mois c'est mieux que -0.3 mais on équilibrera
          if (EnsoleillementParcelle<0)
          {
            EnsoleillementParcelle=0;
          }
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
          //REMPLACER EMPLACEMENT PAR UNE PLANTE NULLE.
        }
        index++;
      } 
    }

}
