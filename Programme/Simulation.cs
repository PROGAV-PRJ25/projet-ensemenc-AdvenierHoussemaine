using System.Security.Cryptography.X509Certificates;

public class Simulation 
{
    static private Random rng = new Random(); //est utilisé pour l'aléatoire
    protected List<Saison> Annee;
    static bool ModeUrgence = false;
    public bool ConditionArret = false;
    public List<Plante> EnsemblePlantes {get; set;} //Utilisé pour répertorié toutes les plantes et avoir leur niveau de croissance.
    public Simulation() //eventuellement rentrer en parametre le pays qu'on veut jouer dans si on garde cette fonctionalité là
    {
        //creer l'année (une liste de mois) 
        Annee = new List<Saison>
        {
            new ("Printemps"),
            new ("Été"),
            new ("Automne"),
            new ("Hiver")
        };
        //creer les terrains 
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
        while (ConditionArret==false)
        {
            // affichage du mois et de la meteo 
            Console.WriteLine(Annee[])
            //on regarde si on est dans le mode urgence ou pas 
            int risqueModeUrgence = rng.Next(0, 5); //Une chance sur 4 d'être en mode urgence.
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