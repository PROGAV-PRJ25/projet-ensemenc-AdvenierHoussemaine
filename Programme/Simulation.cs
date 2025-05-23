using System.Net.Cache;

public class Simulation
{
    private Random rng = new Random(); //est utilisé pour l'aléatoire
    private Annee anneeSimulation;
    private bool conditionArret = false;
    private int NbrTour { get; set; }
    private int ArgentJoueur { get; set; }
    private Terrain TerrainSimulation { get; set; }
    public List<List<Plante>>? EnsemblePlantes { get; set; } //Utilisé pour répertorier toutes les plantes et avoir une vue d'ensemble sur le terrain.
    private PlanteNull PlanteNull { get; set; } //Plante nulle utilisée pour remplacer des plantes.
    public Simulation(Terrain terrainJeu) //Prend en paramètre le type de terrain sur lequel le joueur veut jouer.
    {
        NbrTour = 1;
        ArgentJoueur = 20; //Argent pour débuter le jeu
        anneeSimulation = new Annee();
        TerrainSimulation = terrainJeu;
        //Ajouter des plantes nulles sur les parcelles
        foreach (var parcelle in TerrainSimulation.Parcelles)
        {
            for (int i = 0; i < 12; i++)
            {
                PlanteNull PlanteNullParcelles = new PlanteNull(TerrainSimulation.Parcelles[0]);
                parcelle.Plantes.Add(PlanteNullParcelles);
            }
        }
        EnsemblePlantes = new List<List<Plante>> { };
        foreach (var parcelle in TerrainSimulation.Parcelles)
        {
            EnsemblePlantes!.Add(parcelle.Plantes);
        }
        PlanteNull = new PlanteNull(TerrainSimulation.Parcelles[0]); //On initialise une plante null générique sur une parcelle aléatoire.
    }
    private bool CalculerconditionArret()
    {
        //On veut voir si 3/4 ou plus des 3/4 des plantes sont à une vitesse de croissance de -0,5 ou plus ou si la moitié des plantes sont mortes(CONDITION : si on a 10 plantes ou plus).
        int nombreDePlantes = EnsemblePlantes!.Sum(liste => liste.Count);
        int compteurPlantesFaibles = 0; //Voir combien de plantes ont une vitesse de croissance à moins de -0.2
        int compteurPlantesMortes = 0; //Voir combien de plantes ont une vitesse de croissance à -1.
        foreach (var listePlante in EnsemblePlantes!)
        {
            foreach (var plante in listePlante)
            {
                if (plante.VitesseCroissance <= -0.5) compteurPlantesFaibles++;
                if (plante.VitesseCroissance == -1) compteurPlantesMortes++;
            }
        }
        if (compteurPlantesFaibles >= 0.75 * nombreDePlantes) conditionArret = true;
        if (nombreDePlantes >= 10 && compteurPlantesMortes >= 0.5 * nombreDePlantes) conditionArret = true;
        if (ArgentJoueur == -5) conditionArret = true;

        //On veut mettre la condition à true si le joueur décide d'arrêter de jouer.
        bool robustesse = false;
        do
        {
            Console.WriteLine("Voulez-vous continuer à jouer ? Tappez o ou n.");
            string input = Console.ReadLine()!;
            robustesse = (input == "o" || input == "n"); //Renvoie false si la valeur saisie n'est pas o ou n.
            if (robustesse == true && input == "n") //Va modifier la valeur de la condition d'arrêt à true si le joueur ne veut plus jouer. 
            {
                conditionArret = true;
            }
            else robustesse = false;
        } while (robustesse == false);
        return conditionArret;
    }
    public void Simuler()
    {
        while (conditionArret == false) //Les plantes sont mortes ou le joueur décide d'arreter de jouer (voir méthode CalculerconditionArret)
        {

            Mois moisPourMeteo = anneeSimulation.DonnerLeMois();
            //Apparition des plantes invasives : tous les 5 tours, elles se mettent là partout ou il y a des l'espace libre.
            if (NbrTour % 5 == 0)
            {
                int indiceParcelle = 0;
                foreach (var parcelle in TerrainSimulation.Parcelles)
                {
                    int indexEmplacement = 0;
                    foreach (var emplacement in parcelle.Emplacements)
                    {
                        if (emplacement == " 🟤 ")
                        {
                            TerrainSimulation.Parcelles[indiceParcelle].Emplacements[indexEmplacement] = " 🌱 ";
                        }
                        indexEmplacement++;
                    }
                    indiceParcelle++;
                }

            }
            //on vérifie l'état des plantes
            int indexParcelle = 0; //Pour récuperer la position de la plante sur le terrain.
            foreach (var parcelle in TerrainSimulation.Parcelles)
            {
                int indexPlante = 0;
                foreach (var plante in parcelle.Plantes)
                {
                    if (!(plante is PlanteNull) && !(plante is PlanteInvasive) && plante.NiveauMaturation >= 0)
                    {
                        //Par défaut, les plante s'agrandissent à chaque tour.
                        if (plante.NiveauMaturation <= 3)
                        {
                            plante.NiveauMaturation+=1;
                            TerrainSimulation.Parcelles[indexParcelle].Emplacements[indexPlante] = plante.ImagesPlante![plante.NiveauMaturation];
                        }

                        if (plante.VerificationEtatPlante(moisPourMeteo) == -1) //si la plante n'a pas surveccu on le signale
                        {
                            plante.NiveauMaturation = 0;
                            TerrainSimulation.Parcelles[indexParcelle].Emplacements[indexPlante] = plante.ImagesPlante![0];
                        }
                        if (plante.NiveauMaturation == 4)
                        {
                            Console.WriteLine("\n -> Des plantes ont été ceuillies !");
                            TerrainSimulation.Parcelles[indexParcelle].Emplacements[indexPlante] = " 🟤 ";
                            TerrainSimulation.Parcelles[indexParcelle].Plantes[indexPlante] = PlanteNull;
                            ArgentJoueur += TerrainSimulation.Parcelles[indexParcelle].Plantes[indexPlante].ValeurProduit * TerrainSimulation.Parcelles[indexParcelle].Plantes[indexPlante].ValeurProduit; //Ajouter de l'argent au joueur quand la plante est mure.
                        }
                        else if (plante.NiveauMaturation >= 1 && plante.VerificationEtatPlante(moisPourMeteo) < -0.8) //Si l'état est suffisament mauvais la plante perd en maturité 
                        {
                            plante.NiveauMaturation--;
                            TerrainSimulation.Parcelles[indexParcelle].Emplacements[indexPlante] = plante.ImagesPlante![plante.NiveauMaturation];
                        }
                        
                    }
                    indexPlante++;
                }
                indexParcelle++;
            }
            //AFFICHAGE NOUVEAU TOUR
            Console.Clear();
            Console.WriteLine($"========== TOUR N°{NbrTour} ==========\n\n");
            System.Threading.Thread.Sleep(1500);
            //AFFICHAGE DU MOIS ET DE LA METEO
            Console.WriteLine(anneeSimulation);
            System.Threading.Thread.Sleep(1500);
            //INFLUENCE DE LA METEO SUR LES PARCELLES
            foreach (var parcelle in TerrainSimulation.Parcelles)
            {
                parcelle.InfiltrationDeLaPluie(moisPourMeteo);
                parcelle.InfluenceSolei(moisPourMeteo);
                //Console.WriteLine(parcelle.ToString());
            }
            //DETERMINATION DU MODE URGENCE OU NON
            int risqueModeUrgence = rng.Next(1, 12); //Une chance sur 6 d'être en mode urgence. Il y a deux modes urgence.

            //------MODE URGENCE------
            if (risqueModeUrgence == 1)
            {
                //choix de l'urgence et dire qu'on est en mode urgence ce mois ci 
                Enfant enfant = new Enfant(TerrainSimulation);
                enfant.Urgence();

            }
            else if (risqueModeUrgence == 2)
            {
                Feu feu = new Feu(TerrainSimulation);
                feu.Urgence();
            }

            //-----MODE CLASSIQUE------
            else
            {
                Console.WriteLine("\n\n->Attention ! Des animaux arrivent dans votre potager !");
                System.Threading.Thread.Sleep(1500);
                //Variable aléatoire du choix de l'animal
                int animal = rng.Next(0, 4);
                //Variable aléatoire du choix de la parcelle
                int numParcelle = rng.Next(0, 6);
                //Sanglier
                if (animal == 0)
                {
                    Sanglier sanglier = new Sanglier(numParcelle, TerrainSimulation);
                    if (TerrainSimulation.TerrainProtege == false) sanglier.Action(numParcelle);
                }
                //Escargot
                else if (animal == 1)
                {
                    Escargot escargot = new Escargot(numParcelle, TerrainSimulation);
                    escargot.Action(numParcelle);
                }
                //Abeille
                else if (animal == 2)
                {
                    Abeille abeille = new Abeille(numParcelle, TerrainSimulation);
                    abeille.Action(numParcelle);
                }
                //Ver de terre
                else if (animal == 3)
                {
                    VerDeTerre ver = new VerDeTerre(numParcelle, TerrainSimulation);
                    ver.Action(numParcelle);
                }
                TerrainSimulation.ToActionString();
                System.Threading.Thread.Sleep(3000);
                //ACTIONS DU JOUEUR
                Console.Clear();
                TerrainSimulation.ToClassiqueString();
                Console.WriteLine("\nVous allez pouvoir vous occuper de votre jardin.");
                Console.WriteLine($"--> SOLDE : {ArgentJoueur}🔔");
                bool robustesseAction = false;
                bool robustesseParcelle = false;
                int action;
                int parcelle;
                do
                {
                    Console.WriteLine("\nVous pouvez : \n 1) Arroser une parcelle : 2🔔 \n 2) Déserber une parcelle 2🔔 \n 3) Ombrager une parcelle 5🔔 \n 4) Planter une plante 1🔔 \n 5) Installer un barrière 15🔔\n Tappez 1, 2, 3, 4, 5, 6 ou 0 (pour ne rien faire).");
                    string inputTerrain = Console.ReadLine()!;
                    robustesseAction = int.TryParse(inputTerrain, out action); //Renvoie false si la valeur saisie n'est pas un entier.
                    if (action < 6 && action > 0) //Verifier que l'input du joueur est un entier compris entre 1 et 5.
                    {
                        if (action == 5)
                        {
                            if (ArgentJoueur >= 15)
                            {
                                TerrainSimulation.Proteger();
                                robustesseAction = false;
                                ArgentJoueur -= 15;
                                TerrainSimulation.ToClassiqueString();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("\nVous n'avez pas assez d'argent pour protéger votre terrain.");
                                break;
                            }
                        }
                        else
                        {
                            do
                            {
                                Console.WriteLine("\nSur quelle parcelle voulez-vous agir ?");
                                string inputParcelle = Console.ReadLine()!;
                                robustesseParcelle = int.TryParse(inputParcelle, out parcelle);
                                if (parcelle < 7 && parcelle > 0) //Vérifier que la valeur entrée par le joueur est un enier compris entre 1 et 6.
                                {
                                    switch (action)
                                    {
                                        case 1:
                                            TerrainSimulation.Parcelles[parcelle - 1].Arroser();
                                            robustesseAction = false; //Le joueur peut faire autant d'action qu'il veut (en fonction de son argent).
                                            robustesseParcelle = true;
                                            ArgentJoueur -= 2;
                                            TerrainSimulation.ToActionString();
                                            Console.WriteLine($"\n--> SOLDE : {ArgentJoueur}🔔");
                                            break;
                                        case 2:
                                            TerrainSimulation.Parcelles[parcelle - 1].Desherber();
                                            int index = 0;
                                            foreach (var parc in TerrainSimulation.Parcelles)
                                            {
                                                for (int i = 0; i < 12; i++)
                                                {
                                                    PlanteNull PlanteNullParcelles = new PlanteNull(TerrainSimulation.Parcelles[0]);
                                                    TerrainSimulation.Parcelles[index].Plantes[i] = PlanteNullParcelles;
                                                }
                                                index++;
                                            }
                                            robustesseAction = false; ;
                                            robustesseParcelle = true;
                                            ArgentJoueur -= 2;
                                            TerrainSimulation.ToActionString();
                                            Console.WriteLine($"\n--> SOLDE : {ArgentJoueur}🔔");
                                            break;
                                        case 3:
                                            TerrainSimulation.Parcelles[parcelle - 1].Ombrager();
                                            robustesseAction = false;
                                            robustesseParcelle = true;
                                            ArgentJoueur -= 5;
                                            TerrainSimulation.ToActionString();
                                            Console.WriteLine($"\n--> SOLDE : {ArgentJoueur}🔔");
                                            break;
                                        case 4:
                                            int positionParcelle = 0;
                                            foreach (var emplacement in TerrainSimulation.Parcelles[parcelle - 1].Emplacements) //Parcours la liste pour trouver un emplacement "vide".
                                            {
                                                if (emplacement == " 🟤 ")
                                                {
                                                    TerrainSimulation.Parcelles[parcelle - 1].Planter(TerrainSimulation.Parcelles[parcelle - 1], positionParcelle);
                                                    Console.WriteLine($"{TerrainSimulation.Parcelles[parcelle - 1].Emplacements[positionParcelle]}");
                                                    Console.WriteLine($"{TerrainSimulation.Parcelles[parcelle - 1].Plantes[positionParcelle]}");
                                                    ArgentJoueur -= 1;
                                                    break;
                                                }
                                                else positionParcelle++;
                                            }
                                            TerrainSimulation.ToClassiqueString();
                                            Console.WriteLine($"\n--> SOLDE : {ArgentJoueur}🔔");
                                            robustesseAction = false;
                                            break;
                                        default:
                                            Console.WriteLine("\nL'action que vous avez choisie n'existe pas.");
                                            break;
                                    }
                                }
                                else robustesseParcelle = false;
                            } while (robustesseParcelle == false);
                        }
                    }
                    else if (action == 0) robustesseAction = true; //Sort de la boucle si le joueur ne veut pas/plus faire d'action.
                    else robustesseAction = false;
                    //TerrainSimulation.ToClassiqueString(); 
                } while (robustesseAction == false && ArgentJoueur >= 1);

            }
            //Read key pour que le joueur fasse enter pour avancer dans le jeu.
            // On change de mois
            anneeSimulation.ChangerDeMois();
            NbrTour++;
            CalculerconditionArret(); //Demander au joueur s'il veut continuer à jouer.
        }
    }
}