public class Simulation 
{
    static private Random rng = new Random(); //est utilisé pour l'aléatoire
    protected Annee AnneeSimulation;
    static bool ModeUrgence = false;
    public bool conditionArret = false;
    public Simulation() //eventuellement rentrer en parametre le pays qu'on veut jouer dans si on garde cette fonctionalité là
    {
        //creer l'année 
        AnneeSimulation = new Annee();

        //creer les terrains 

    }

    public void Simuler()
    {
        while (conditionArret==false)
        {
            // affichage du mois et de la meteo 
            Console.WriteLine(AnneeSimulation);

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