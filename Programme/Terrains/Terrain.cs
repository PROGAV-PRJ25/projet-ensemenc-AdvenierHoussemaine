using System.Reflection;

public abstract class Terrain
{
    public string NumTerrain {get;set;} //Pour pouvoir identifier les terrains
    public double HumiditeTerrain {get; set;} //Allant de 0(très sec) à 1(très humide)
    public double EnsoleillementTerrain {get; set;} //Allant de 0(ombragé) à 1(plein soleil)
    public List<Parcelle> Parcelles {get; set;} //Dans chaque terrain, il y a 12 emplacements pour planter des plantes. Dans chacune des ces parcelles, il y a 6 "unités d'espace".
    public string TypeTerrain {get; set;} = string.Empty; //Determine si le terrain est argileux, rocheux, tourbière ou sableux.

    public Terrain(string numTerrain)
    {
        //Lorsque l'on initalise un terrain, il est vide 'o'.
        List<string> charInitiaux = new List<string> {"🟤", "🟤","🟤", "🟤", "🟤", "🟤"};
        Parcelles  = new List<Parcelle> {};
        for (int i=0; i<6; i++)
        {
            Parcelle parcelle = new Parcelle($"{numTerrain}.{i+1}", charInitiaux);
            Parcelles.Add(parcelle);
        }
        NumTerrain = numTerrain;
        EnsoleillementTerrain = 0.5; //La valeur par défault au moment de l'initalisation.
        if (TypeTerrain == "Tourbière") HumiditeTerrain = 1;
        else if (TypeTerrain == "Argileux") HumiditeTerrain = 0.4;
        else if (TypeTerrain == "Sableux") HumiditeTerrain = 0.7;
        else if (TypeTerrain == "Rocheux") HumiditeTerrain = 0.2;
    }
    public void Arroser()
    {
        //MODIFIER LA VALEUR DE L'HUMIDITE DU TERRAIN
        bool robustesse = true;
        int intensiteArrosage;
        do
        {
            Console.WriteLine("Vous avez choisi d'arroser votre terrain.");
            Console.WriteLine("A quel point voulez-vous arroser vos plantes ? (Tappez 1 2 ou 3)");
            string input = Console.ReadLine()!;
            robustesse = int.TryParse(input, out intensiteArrosage); //Renvoie false si la valeur saisie n'est pas un entier.
            if (robustesse == true) //Va modofier la valeur de l'humidité si la valeur entrée est un entier.
            {
                intensiteArrosage = Convert.ToInt32(input);
                //Il y a trois intensités d'arrosage, le joueur peut tapper 1 2 ou 3.
                if (intensiteArrosage == 1) HumiditeTerrain += 0.1;
                else if (intensiteArrosage == 2) HumiditeTerrain += 0.2;
                else if (intensiteArrosage == 3) HumiditeTerrain += 0.3;
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
            robustesse = (input == "o" || input == "n"); //Renvoie false si la valeur saisie n'est pas un entier.
            if (robustesse == true && input == "o") //Va modifier la valeur de l'ensoleillement si la valeur entrée est o ou n.
            {
                EnsoleillementTerrain -= 0.3;
            }
            else robustesse = false;
        }while(robustesse == false);
    }
    public void TraiterMaladie()
    {
        Console.WriteLine("Vous avez choisi de traiter les plantes de votre terrain.");
        //EN CAS DE MALADIE, ENLEVE LES DOMMAGES CAUSEES A LA PLANTE.
        foreach (var parcelle in Parcelles)
        {
            foreach (var plante in parcelle.Plantes)
            {
                plante.VitesseCroissance += 0.4; //Une maladie inflige un dégat de 0.5 à la plante, la traiter permet de récupérer 0.1 points de croissance.
            }
        }
    }
    public void Desherber()
    {
        foreach(var parcelle in Parcelles)
        {
            int index = 0; //On veut récupérer l'indice des itérations emplacement.
            foreach(var emplacement in parcelle.Emplacements)
            {
                if (emplacement == "🌱") 
                {
                    parcelle.Emplacements[index] = "🟤";
                    index++;
                }
            } 
        }
    }
    public override string ToString()
    {   
        //if CLASSIQUE
        string affichageSousTerrain = " ";
        foreach (var parcelle in Parcelles)
        {
            string elementsListe = " ";
            foreach (var element in parcelle.Emplacements)
            {
                elementsListe += element;
            }
            affichageSousTerrain += $"\n    Parcelle {parcelle.NumParcelle} : {elementsListe}";
        }
        string affichage = $"=== TERRAIN {NumTerrain} === \n     -> Type : {TypeTerrain}\n     -> Humidité : {HumiditeTerrain} \n Voici le détail des parcelles : {affichageSousTerrain}";
        return affichage;
        
        //if URGENCE
    }
}


/*Méthodes à mettre
Drainer : faire un truc proportionnel aux nombre de plantes, enlever un peu d'eau à chaque tour, se fait automatiquement à la fin du jeu
*/
