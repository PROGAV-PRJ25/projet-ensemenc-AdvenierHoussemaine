public class Simulation 
{
    static private Random rng = new Random(); //est utilisé pour l'aléatoire
    protected Annee AnneeSimulation;
    static bool ModeUrgence = false;
    public bool ConditionArret = false;
    public Terrain TerrainSimulation {get; set;}
    public List<List<Plante>> EnsemblePlantes {get; set;} //Utilisé pour répertorier toutes les plantes et avoir une vue d'ensemble sur le terrain.
    public Simulation(Terrain terrainJeu) //Prend en paramètre le type de terrain sur lequel le joueur veut jouer.
    {
        AnneeSimulation = new Annee();
        TerrainSimulation = terrainJeu;
        foreach (var parcelle in TerrainSimulation.Parcelles)
        {
            EnsemblePlantes!.Add(parcelle.Plantes); 
        }
    }
    public bool CalculerConditionArret()
    {
        //On veut voir si 3/4 ou plus des 3/4 des plantes sont à une vitesse de croissance de -0,5 ou plus ou si la moitié des plantes sont mortes(CONTITION : si on a 10 plantes ou plus).
        double moyenneEtatPlantes;
        int nombreDePlantes = EnsemblePlantes.Count;
        int compteurPlantesFaibles = 0; //Voir combien de plantes ont une vitesse de croissance à moins de -0.5
        int compteurPlantesMortes = 0; //Voir combien de plantes ont une vitesse de croissance à -1.
        foreach(var plante in EnsemblePlantes)
        {
            if (plante.VitesseCroissance <= -0.5) compteurPlantesFaibles++;
            if (plante.VitesseCroissance == -1) compteurPlantesMortes++;
        }
        if(compteurPlantesFaibles >= 0.75*nombreDePlantes) ConditionArret = true;
        if (nombreDePlantes >= 10) ConditionArret = true;

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
        {
            //On regarde si on est dans le mode urgence ou pas.
            int risqueModeUrgence = rng.Next(1, 4); //Une chance sur 4 d'être en mode urgence.
            //MODE URGENCE
            if (risqueModeUrgence == 1)
            {
                ModeUrgence = true;
                Console.WriteLine(AnneeSimulation); //Affichage du mois et de la meteo.
            
                //choix de l'urgence et dire qu'on est en mode urgence ce mois ci  
                //affichage du nom de l'urgence 
                //boucle while l'urgence est pas réglé ou que le joueur à perdu 
            }

            //MODE CLASSIQUE
            else 
            {   
                Console.WriteLine(AnneeSimulation); //Affichage du mois et de la meteo.
                int animal = rng.Next(1, 4);
                //Sanglier
                if (animal == 0)
                {
                    Sanglier sanglier = new Sanglier();
                    sanglier.Action();
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

        
                //affichage score d'action restant
                //affichage des actions possibles 
                while (actionRestantes>0 && rienFaire==false)
                {
                    //demander l'action souhaité 
                    //executer l'action 
                    //mise à jour des variables (eventuellement déjà dasn l'action)
                    //incrementation du nombre d'action restantes
                    //affichage score d'action restantes
                }
            }
            //verification si la condition d'arret est validé
            //affichage de l'état du jeu 
            Console.WriteLine(Simulation.Terrain());
            // un temp de latence ou une attente que l'utilisateur tape sur une touche pour passer au prochain mois         
        }
    }
    public void Simuler()
    {
        while (conditionArret==false)
        {
            int X= Annee.NomDeLannee;
            // affichage du mois et de la meteo 
            Console.WriteLine(AnneeSimulation.AnneeActuel[AnneeSimulation.AnneeActuel[ AnneeSimulation.SaisonActuel]])

            //on regarde si on est dans le mode urgence ou pas 
            int risqueModeUrgence = rng.Next(0, 5);
            if (risqueModeUrgence==0)
            {
                ModeUrgence = true;
                //choix de l'urgence et dire qu'on est en mode urgence ce mois ci  
                //affichage du nom de l'urgence 
                //boucle while l'urgence est pas réglé ou que le joueur à perdu 
            }
            else 
            {
                
                Console.WriteLine(Simulation.MeteoDuMois());
                //choix d'une créature qui nuit 
                //affichage de la créature
        
                //affichage score d'action restant
                //affichage des actions possibles 
                while (actionRestantes>0 && rienFaire==false)
                {
                    //demander l'action souhaité 
                    //executer l'action 
                    //mise à jour des variables (eventuellement déjà dasn l'action)
                    //incrementation du nombre d'action restantes
                    //affichage score d'action restantes
                }
            }
            //verification si la condition d'arret est validé
            //affichage de l'état du jeu 
            Console.WriteLine(Simulation.Terrain());
            // un temp de latence ou une attente que l'utilisateur tape sur une touche pour passer au prochain mois
             
        }
    }
}