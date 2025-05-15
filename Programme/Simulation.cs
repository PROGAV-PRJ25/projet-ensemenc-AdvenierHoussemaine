using System.Net.Cache;

public class Simulation 
{
    static private Random rng = new Random(); //est utilisé pour l'aléatoire
    protected Annee AnneeSimulation;
    public bool ConditionArret = false;
    public int ArgentJoueur {get; set;}
    public Terrain TerrainSimulation {get; set;}
    public List<List<Plante>>? EnsemblePlantes {get; set;} //Utilisé pour répertorier toutes les plantes et avoir une vue d'ensemble sur le terrain.
    public Simulation(Terrain terrainJeu) //Prend en paramètre le type de terrain sur lequel le joueur veut jouer.
    {
        ArgentJoueur = 10; //Argent pour débuter le jeu
        AnneeSimulation = new Annee();
        TerrainSimulation = terrainJeu;
        EnsemblePlantes = new List<List<Plante>>{};
        foreach (var parcelle in TerrainSimulation.Parcelles)
        {
            EnsemblePlantes!.Add(parcelle.Plantes); 
        }
    }
    public bool CalculerConditionArret()
    {
        //On veut voir si 3/4 ou plus des 3/4 des plantes sont à une vitesse de croissance de -0,5 ou plus ou si la moitié des plantes sont mortes(CONTITION : si on a 10 plantes ou plus).
        int nombreDePlantes = EnsemblePlantes!.Sum(liste => liste.Count);
        int compteurPlantesFaibles = 0; //Voir combien de plantes ont une vitesse de croissance à moins de -0.5
        int compteurPlantesMortes = 0; //Voir combien de plantes ont une vitesse de croissance à -1.
        foreach(var listePlante in EnsemblePlantes!)
        {
            foreach(var plante in listePlante)
            {
                if (plante.VitesseCroissance <= -0.5) compteurPlantesFaibles++;
                if (plante.VitesseCroissance == -1) compteurPlantesMortes++;
            }
        }
        if(compteurPlantesFaibles >= 0.75*nombreDePlantes) ConditionArret = true;
        if (nombreDePlantes >= 10 && compteurPlantesMortes >= 0.5 * nombreDePlantes) ConditionArret = true;

        //On veut mettre la condition à true si le joueur décide d'arrêter de jouer.
        bool robustesse = false;
        do
        {
            Console.WriteLine("Voulez-vous continuer à jouer ? Tappez o ou n.");
            string input = Console.ReadLine()!;
            robustesse = (input == "o" || input == "n"); //Renvoie false si la valeur saisie n'est pas o ou n.
            if (robustesse == true && input == "n") //Va modifier la valeur de la condition d'arrêt à true si le joueur ne veut plus jouer. 
            {
                ConditionArret = true;
            }
            else robustesse = false;
        }while(robustesse == false);
        return ConditionArret;
    }
    public void Simuler()
    {
        while (ConditionArret == false) //Les plantes sont mortes ou le joueur décide d'arreter de jouer (voir méthode CalculerConditionArret)
        {   //AFFICHAGE DU MOIS ET DE LA METEO
            Console.WriteLine(AnneeSimulation);

            //DETERMINATION DU MODE URGENCE OU NON
            int risqueModeUrgence = rng.Next(1, 4); //Une chance sur 4 d'être en mode urgence.
            
            //------MODE URGENCE------
            if (risqueModeUrgence == 1)
            {    
                TerrainSimulation.ToUrgenceString();  
                //choix de l'urgence et dire qu'on est en mode urgence ce mois ci 
                Enfant enfant = new Enfant(TerrainSimulation);
                enfant.Urgence();
                //affichage du nom de l'urgence 
                //boucle while l'urgence est pas réglé ou que le joueur à perdu 
            }

            //-----MODE CLASSIQUE------
            else 
            {   
                /*
                int animal = rng.Next(0, 4);
                //Sanglier
                if (animal == 0)
                {
                    Sanglier sanglier = new Sanglier();
                    if (TerrainSimulation.TerrainProtege == false) sanglier.Action();
                    //Console.WriteLine(TerrainSimulation)
                }
                //Escargot
                else if (animal == 1)
                {
                    Escargot escargot = new Escargot();
                    escargot.Action();
                    //Console.WriteLine(TerrainSimulation)
                }
                //Abeille
                else if (animal == 2)
                {
                    Abeille abeille = new Abeille();
                    abeille.Action();
                    //Console.WriteLine(TerrainSimulation)
                }
                //Ver de terre
                else if (animal == 3)
                {
                    VerDeTerre ver = new VerDeTerre();
                    ver.Action();
                    //Console.WriteLine(TerrainSimulation)
                }
                */
                
                //ACTIONS DU JOUEUR
                TerrainSimulation.ToClassiqueString(); 
                Console.WriteLine("Vous allez pouvoir vous occuper de votre jardin.");
                Console.WriteLine($"--> SOLDE : {ArgentJoueur}🔔");
                bool robustesseAction = false;
                bool robustesseParcelle = false;
                int action;
                int parcelle;
                do
                {
                    Console.WriteLine("Vous pouvez : \n 1) Arroser une parcelle : 2🔔. \n 2) Déserber une parcelle 2🔔. \n 3) Ombrager une parcelle 5🔔. \n 4) Traiter le sol de votre parcelle pour les soigner une maladie 5🔔 \n 5) Planter une plante 1🔔 \n 6) Installer un barrière 15🔔\n Tappez 1, 2, 3, 4, 5, 6 ou 0 (pour ne rien faire).");
                    string inputTerrain = Console.ReadLine()!;
                    robustesseAction = int.TryParse(inputTerrain, out action); //Renvoie false si la valeur saisie n'est pas un entier.
                    if (action < 7 && action > 0) //Verifier que l'input du joueur est un entier compris entre 1 et 4.
                    {
                        do
                        {
                            Console.WriteLine("Sur quelle parcelle voulez-vous agir ?");
                            string inputParcelle = Console.ReadLine()!;
                            robustesseParcelle = int.TryParse(inputParcelle, out parcelle);
                            if (parcelle < 7 && parcelle > 0) //Vérifier que la valeur entrée par le joueur est un enier compris entre 1 et 6.
                            switch(action)
                            {
                                case 1:
                                    TerrainSimulation.Parcelles[parcelle-1].Arroser();
                                    robustesseAction = false; //Le joueur peut faire autant d'action qu'il veut (en fonction de son argent).
                                    robustesseParcelle = true;
                                    ArgentJoueur -= 2;
                                    break;
                                case 2:
                                    TerrainSimulation.Parcelles[parcelle-1].Desherber();
                                    robustesseAction = false;;
                                    robustesseParcelle = true;
                                    ArgentJoueur -= 2;
                                    break;
                                case 3:
                                    TerrainSimulation.Parcelles[parcelle-1].Ombrager();
                                    robustesseAction = false;
                                    robustesseParcelle = true;
                                    ArgentJoueur -= 5;
                                    break;
                                case 4:
                                    TerrainSimulation.Parcelles[parcelle-1].TraiterMaladie();
                                    robustesseAction = false;
                                    robustesseParcelle = true;
                                    ArgentJoueur -= 5;
                                    break;
                                case 5:
                                    foreach(var emplacement in TerrainSimulation.Parcelles[parcelle-1].Emplacements) //Parcours la liste pour trouver un emplacement "vide".
                                    {
                                        int positionParcelle = 0;
                                        if (emplacement == "🟤")
                                        {
                                            TerrainSimulation.Parcelles[parcelle-1].Planter(TerrainSimulation.Parcelles[parcelle-1],positionParcelle);
                                            ArgentJoueur -= 1; //Voir si on change le prix en fonction de la plante
                                            break;
                                        }
                                        positionParcelle++;
                                    }
                                    break;
                                case 6:
                                    TerrainSimulation.Proteger();
                                    robustesseAction = false;
                                    robustesseParcelle = true;
                                    ArgentJoueur -= 15;
                                    break;
                                default:
                                    Console.WriteLine("L'action que vous avez choisie n'existe pas.");
                                    break;
                            }
                        }while (robustesseParcelle == false);  
                    }
                    else if (action == 0) robustesseAction = true; //Sort de la boucle si le joueur ne veut pas/plus faire d'action.
                    TerrainSimulation.ToClassiqueString(); 
                }while (robustesseAction == false && ArgentJoueur >= 1);
            }
            Console.WriteLine(TerrainSimulation);
            //Read key pour que le joueur fasse enter pour avancer dans le jeu.    
        }
    }
}