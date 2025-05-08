public abstract class Terrain
{
    public string NumTerrain {get;set;} //Pour pouvoir identifier les terrains
    public double HumiditeTerrain {get; set;} //Allant de 0(très sec) à 1(très humide)
    public List<Parcelle> SousTerrains {get; set;} //Dans chaque terrain, il y a 6 emplacements pour pkanter des fleurs. Dans chacune des ces parcelles, il y a 6 "unités d'espace".
    public string TypeTerrain {get; set;} //Determine si le terrain est argileux, cailloux, tourbière ou mare.

    public Terrain(string numTerrain, string typeTerrain)
    {
        //Lorsque l'on initalise un terrain, il est vide 'o'.
        List<string> charInitiaux = new List<string> {"🟤", "🟤","🟤", "🟤", "🟤", "🟤"};
        SousTerrains = new List<Parcelle> {};
        for (int i=0; i<6; i++)
        {
            Parcelle parcelle = new Parcelle($"{numTerrain}.{i+1}", charInitiaux);
            SousTerrains.Add(parcelle);
        }
        HumiditeTerrain = 0.5; //A l'initalisation, l'humidité est par défaut à 0.5. ---- dépendra du type de terrain
        NumTerrain = numTerrain;
        if (typeTerrain == "Tourbière") HumiditeTerrain = 1;
        else if (typeTerrain == "Argileux") HumiditeTerrain = 0.4;
        else if (typeTerrain == "Sableux") HumiditeTerrain = 0.7;
        else if (typeTerrain == "Rocheux") HumiditeTerrain = 0.2;
    }

    public void Arroser() //Ajouter la modification du taux d'eau des plantes
    {
        //MODIFIER LA VALEUR DE L'HUMIDITE DU TERRAIN
        bool robustesse = true;
        int intensiteArrosage;
        do
        {
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
    
        //MODIFIER L'ETAT DE LA PLANTE
        foreach (var parcelle in SousTerrains)
        {
            foreach(var emplacement in parcelle.Emplacements)
            {
                if (emplacement != "🟤")//Différent d'un emplacement vide + voir encore comment on gère les plantes qui prennent de la place (_?)
                {
                    //modifier le taux d'eau de la plante
                }
            }
        }
    }
    public void Ombrager()
    {
        //MODIFIER L'ETAT DE LA PLANTE
        foreach (var parcelle in SousTerrains)
        {
            foreach(var emplacement in parcelle.Emplacements)
            {
                if (emplacement != "🟤")//Différent d'un emplacement vide + voir encore comment on gère les plantes qui prennent de la place (_?)
                {
                    //modifier l'ensoleillement de la plante
                }
            }
        }
    }
    public override string ToString()
    {
        string affichageSousTerrain = " ";
        foreach (var parcelle in SousTerrains)
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
    }
}


/*Méthodes à mettre
Drainer : faire un truc proportionnel aux nombre de plantes, enlever un peu d'eau à chaque tour, se fait automatiquement à la fin du jeu

 - Actions du joueur -
Traiter :
Proteger :
*/

